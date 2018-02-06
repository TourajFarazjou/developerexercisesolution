using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExerciseWebApplication.App_Start;

namespace ExerciseWebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocConfig.ConfigureIoCcontainer();
        }
    }
}