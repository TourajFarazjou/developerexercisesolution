using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExerciseWebApplication.Services;
using ExerciseWebApplication.ViewModels;

namespace ExerciseWebApplication.Controllers
{
    public class DistanceController : Controller
    {
        private IDataService _DataService;
        private ILocationService _LocationService;

        public DistanceController(IDataService dataService, ILocationService locationService)
        {
            _DataService = dataService;
            _LocationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var airports = await _DataService.GetAirportsByContinent("EU");
            var model = new DistanceViewModel()
            {
                AvailableAirports = airports
                        .Where(n => !string.IsNullOrEmpty(n.lat) && !string.IsNullOrEmpty(n.lon))
                        .Select(n => n.iata)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> Calculate(string codeA, string codeB)
        {
            var airportA = await _DataService.GetAirportByCode(codeA);
            var airportB = await _DataService.GetAirportByCode(codeB);

            // Example location: "28.994328,77.704871"
            var distance = _LocationService.ComputeDistance($"{airportA.lat},{airportA.lon}", $"{airportB.lat},{airportB.lon}");  
            if (distance.HasValue)
                return Json(distance.ToString(), JsonRequestBehavior.AllowGet);

            return Json("error", JsonRequestBehavior.AllowGet);
        }

    }
}