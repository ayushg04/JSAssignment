using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReadExcelFile
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/
            routes.MapRoute("ReadExcelPageOne", "ReadExcel", new { controller = "ReadExcel", action = "Index", page = 1 });

            routes.MapRoute(
                name: "ReadExcelLinks",
                url: "ReadExcel/{page}/",
                defaults: new { controller = "ReadExcel", action = "Index", page = "" },
                constraints: new { page = @"^[0-9]+$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ReadExcel", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
