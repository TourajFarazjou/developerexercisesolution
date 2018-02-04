using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExerciseWebApplication.Models;
using Newtonsoft.Json;

namespace ExerciseWebApplication.Services
{
    public class DataService : IDataService
    {
        private const string CacheDataKey = "AirportJsonData";
        private const int AbsoluteExpiration = 5;

        private string _RequestUrl = "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";

        private IDataCacheService _DataCacheService;

        public DataService(IDataCacheService dataCacheService)
        {
            _DataCacheService = dataCacheService;
        }

        public async Task<IEnumerable<Airport>> GetAirportsByContinent(string continent)
        {
            var allAirports = await GetAllAirports();

            return allAirports.Where(c => c.continent.Equals(continent, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<IEnumerable<Airport>> GetAllAirports()
        {
            string responseData;

            var cachedData = _DataCacheService.Get(CacheDataKey);

            if (cachedData != null)
            {
                responseData = cachedData as string;
            }
            else
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(_RequestUrl);
                    response.EnsureSuccessStatusCode();
                    response.Headers.Add("from-feed", "JSON feed");

                    using (HttpContent content = response.Content)
                    {
                        responseData = await response.Content.ReadAsStringAsync();

                        _DataCacheService.Insert(CacheDataKey, responseData, DateTime.Now.AddMinutes(AbsoluteExpiration));
                    }
                }
            }

            return JsonConvert.DeserializeObject<IEnumerable<Airport>>(responseData);
        }
    }

}