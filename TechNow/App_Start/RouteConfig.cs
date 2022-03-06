using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechNow
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Shopping Site",
            url: "shopping-site",
            defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
         );

            routes.MapRoute(
            name: "Register",
            url: "register",
            defaults: new { controller = "Customers", action = "Create", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
    );



            routes.MapRoute(
            name: "Login",
            url: "login",
            defaults: new { controller = "Customers", action = "CustomerLogin", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
    );



            routes.MapRoute(
            name: "About Us",
            url: "about-us",
            defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
        );

          

            routes.MapRoute(
            name: "Product Detail",
            url: "detail/{metatitle}-{id}",
            defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
        );

            routes.MapRoute(
          name: "News Category",
          url: "news/category/{metatitle}-{newcateId}",
          defaults: new { controller = "News", action = "CategoryNews", id = UrlParameter.Optional },
          namespaces: new[] { "TechNow.Controllers" }
      );

            routes.MapRoute(
            name: "Product Category",
            url: "{product}/{metatitle}-{cateId}",
            defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
        );


            routes.MapRoute(
         name: "News",
         url: "news",
         defaults: new { controller = "News", action = "News", id = UrlParameter.Optional },
         namespaces: new[] { "TechNow.Controllers" }
      );

            routes.MapRoute(
           name: "News Detail",
           url: "{news}/{detail}/{metatitle}-{newsId}",
           defaults: new { controller = "News", action = "DetailNews" },
           namespaces: new[] { "TechNow.Controllers" }
       );

          

            routes.MapRoute(
            name: "Add to Cart",
            url: "cart",
            defaults: new { controller = "ShoppingCart", action = "AddtoCard", id = UrlParameter.Optional },
            namespaces: new[] { "TechNow.Controllers" }
      );
            routes.MapRoute(
           name: "Search",
           url: "search",
           defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
           namespaces: new[] { "TechNow.Controllers" }
     );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechNow.Controllers" }
            );

          
        }
    }
}
