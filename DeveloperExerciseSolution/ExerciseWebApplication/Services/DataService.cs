using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ExerciseWebApplication.Models;
using Newtonsoft.Json;

namespace ExerciseWebApplication.Services
{
    public class DataService : IDataService
    {
        private const string CacheDataKey = "AirportJsonDataKey";
        private const int AbsoluteExpiration = 5;

        private IDataCacheService _DataCacheService;
        private string _RequestUri; 

        public DataService(IDataCacheService dataCacheService)
        {
            _RequestUri = ConfigurationManager.AppSettings["AirportsRequestUri"];
            _DataCacheService = dataCacheService;
        }

        public async Task<Airport> GetAirportByCode(string code)
        {
            var allAirports = await GetAllAirports();

            return allAirports.FirstOrDefault(c => c.iata.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<IEnumerable<Airport>> GetAirportsByContinent(string continent)
        {
            var allAirports = await GetAllAirports();

            return allAirports.Where(c => c.continent.Equals(continent, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<IEnumerable<Airport>> GetAllAirports()
        {
            string responseData;
            string fromFeed;

            var cachedData = _DataCacheService.Get(CacheDataKey);

            if (cachedData != null)
            {
                fromFeed = "Cache";
                responseData = cachedData as string;
            }
            else
            {
                fromFeed = "JSON feed";
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(_RequestUri);
                    response.EnsureSuccessStatusCode();
                    using (var content = response.Content)
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                        _DataCacheService.Insert(CacheDataKey, responseData, DateTime.Now.AddMinutes(AbsoluteExpiration));
                    }
                }
            }
            HttpContext.Current.Response.AddHeader("from-feed", fromFeed);

            return JsonConvert.DeserializeObject<IEnumerable<Airport>>(responseData);
        }
    }

}