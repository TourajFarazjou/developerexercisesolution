using ExerciseWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseWebApplication.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Airport>> GetAirportsByContinent(string continent);

        //Task<IEnumerable<Airport>> GetAirportsByCountry(string country);
    }
}
