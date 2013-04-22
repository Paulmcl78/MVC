using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(new LegacyRoute("~/articles/windows_3.1_Overview.html", "~/old/NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute","{controller}/{action}/{id}",new{controller="Home", action="Index", id=UrlParameter.Optional});


            //One way to register routes
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            //cleaner way to register routes
            //routes.MapRoute("MyRoute", "{controller}/{action}");


            //routes.MapRoute("Shopschema2", "Shop/OldAction", new {controller = "Home", action="Index"});

            //routes.MapRoute("ShopeSchema", "Shop/{action}", new { controller = "Home" });

            //Static and dynamic routes e.g. /XHome/Index
            //routes.MapRoute("", "X{controller}/{action}");
            
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });

            //Static routing
            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });

            //Optional parameters
            //routes.MapRoute("MyRoute2", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //Catch all
            //routes.MapRoute("MyRoute2", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //Give priority to a controllers in a namespace incase multple controllers with the same name exists in other libs
            //routes.MapRoute("MyRoute2", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "AdditionalControllers" });

            //Tell MVC to only look in a given namespace
            //Route myRoute = routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "UrlsAndRoutes.Controllers" });
            //myRoute.DataTokens["UseNamespaceFallback"] = false;

            //Constraining routes - Using regular expression
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { controller = "^H.*" }, new[] { "UrlsAndRoutes.Controllers" });
            
            //Constraining routes - Using HTTP Methods
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { httpMethod = new HttpMethodConstraint("Get","POST") }, new[] { "UrlsAndRoutes.Controllers" });

            //Force our routing to be evaluated before disk files so content/StaticContent.html will route to our login page vs the static page.
            //routes.RouteExistingFiles = true;
            //routes.MapRoute("DiskFile", "Content/{filename}.html", new { controller = "Account", action = "LogOn" });

            //ignore routes.
            //routes.IgnoreRoute("Content/{filename}.html");

            //Constraining routes - using custom contraint UserAgentContraint
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { customConstraint = new UserAgentConstraint("Chrome") }, new[] { "UrlsAndRoutes.Controllers" });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
        }
    }
}