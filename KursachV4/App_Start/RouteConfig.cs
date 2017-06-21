using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KursachV4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Arraiving",
                url: "Arraiving/Index",
                defaults: new { controller = "Arraiving", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
              name: "Consumption",
              url: "Consumption/Index",
              defaults: new { controller = "Consumption", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "LogIn",
                 url: "Account/Login",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

                routes.MapRoute(
                 name: "ConvertHtmlPageToPdfProvider",
                 url: "Provider/ConvertHtmlPageToPdf",
                 defaults: new { controller = "ProviderController", action = "ConvertHtmlPageToPdf", id = UrlParameter.Optional }
             );
               routes.MapRoute(
                   name: "ConvertHtmlPageToPdfConsumption",
                   url: "Consumption/ConvertHtmlPageToPdf",
                   defaults: new { controller = "ConsumptionProvider", action = "ConvertHtmlPageToPdf", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "LogOff",
               url: "Account/LogOff",
               defaults: new { controller = "Account", action = "LogOff", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "ConvertHtmlPageToPdf",
                url: "Scrap/ConvertHtmlPageToPdf",
                defaults: new { controller = "Scrap", action = "ConvertHtmlPageToPdf", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "createMetal",
            url: "Scrap/Create",
            defaults: new { controller = "Scrap", action = "Create", id = UrlParameter.Optional }
        );
            routes.MapRoute(
         name: "createStore",
         url: "Store/Create",
         defaults: new { controller = "Store", action = "Create", id = UrlParameter.Optional }
     );
            routes.MapRoute(
         name: "createReceiver",
          url: "Receiver/Create",
          defaults: new { controller = "Receiver", action = "Create", id = UrlParameter.Optional }
      );
            routes.MapRoute(
          name: "createProvider",
          url: "Provider/Create",
          defaults: new { controller = "Provider", action = "Create", id = UrlParameter.Optional }
      );
            routes.MapRoute(
          name: "createArraiving",
          url: "Arraiving/Create",
          defaults: new { controller = "Arraiving", action = "Create", id = UrlParameter.Optional }
      );
            routes.MapRoute(
          name: "createConsumption",
          url: "Consumption/Create",
          defaults: new { controller = "Consumption", action = "Create", id = UrlParameter.Optional }
      );
            routes.MapRoute(
              name: "VIPProviders",
              url: "Provider/VIPProdivers",
              defaults: new { controller = "Provider", action = "VIPProdivers", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "ProviderReceiverInterconnection",
               url: "Receiver/ProviderReceiverInterconnection",
               defaults: new { controller = "Receiver", action = "ProviderReceiverInterconnection", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "ArraivingDetails",
              url: "Arraiving/GetDetailsOfArraivedMetal",
              defaults: new { controller = "Arraiving", action = "GetDetailsOfArraivedMetal", id = UrlParameter.Optional }
          );
        }
    }

}