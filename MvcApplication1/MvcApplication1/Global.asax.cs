using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApplication1.Common;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyRazorViewEngines());
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            //routes.IgnoreRoute("scripts/images/{*pathInfo}");
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional} 
                );
        }
    }
}