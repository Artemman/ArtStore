﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "",
                new
                {
                    controller = "Home",
                    action = "Index",
                    category = (string)null,
                    page = 1
                });
            routes.MapRoute(null, "Page{page}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    category = (string)null,
                },
                new
                {
                    page = @"\d+"
                });
            routes.MapRoute(null, 
                "Product/{productId}",
              new
              {
                  controller = "Info",
                  action = "Index"
              });
            routes.MapRoute(null,
                "{category}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    page = 1,
                });
            routes.MapRoute(null,
            "{category}/Page{page}",
            new { controller = "Home", action = "Index" },
            new { page = @"\d+" }
            );
          
            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}