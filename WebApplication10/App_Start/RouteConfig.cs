using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication10
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            // Route for AddStudent
            routes.MapRoute(
                name: "AddStudent",
                url: "Student/AddStudent",
                defaults: new { controller = "Student", action = "AddStudent" }
            );
            routes.MapRoute(
                name: "DisplayStudents1",
                url: "Student/DisplayStudents",
                defaults: new { controller = "Student", action = "DisplayStudents" }
            );

            // Specific route for DisplayStudents
            routes.MapRoute(
                name: "DisplayStudents",
                url: "Student/DisplayStudents/{id}",
                defaults: new { controller = "Student", action = "DisplayStudents", id = UrlParameter.Optional }
            );
            
            

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
