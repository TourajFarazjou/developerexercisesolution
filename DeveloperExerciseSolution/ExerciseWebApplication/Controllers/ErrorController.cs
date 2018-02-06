using System.Web.Mvc;

namespace ExerciseWebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }
    }
}