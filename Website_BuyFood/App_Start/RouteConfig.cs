using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Website_BuyFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Menu",
                url: "Menu",
               defaults: new { controller = "Home", action = "Menu", id = UrlParameter.Optional },
               namespaces: new[] { "Website_BuyFood.Controllers" }
            );
            routes.MapRoute(
               name: "About",
               url: "About",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
               namespaces: new[] { "Website_BuyFood.Controllers" }
           );


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            //Huynh chinh lai routes 
            // do có them Areas admin nên cần chỉnh lại đính danh là k phai vào admin 
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "Website_BuyFood.Controllers" }
            );
        }
    }
}
