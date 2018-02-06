using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseWebApplication.Models;

namespace ExerciseWebApplication.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Airport>> GetAirportsByContinent(string continent);

        Task<Airport> GetAirportByCode(string code);
    }
}
