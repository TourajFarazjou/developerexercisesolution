using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using ExerciseWebApplication.Services;
using ExerciseWebApplication.ViewModels;

namespace ExerciseWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IDataService _DataService;

        public HomeController(IDataService dataService)
        {
            _DataService = dataService;
        }

        // GET: Home
        [HttpGet]
        public async Task<ActionResult> Index(string country, int? page)
        {
            var airports = await _DataService.GetAirportsByContinent("EU");

            var model = new HomeViewModel()
            {
                Airports = airports.Where(c => c.iso.Equals(country, StringComparison.CurrentCultureIgnoreCase)).ToPagedList(page ?? 1, 10),
                AvailableCountries = airports.OrderBy(c => c.iso).Select(c => c.iso).Distinct(),
            };

            return View(model);
        }
    }

}