using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Areas.Shop
{
    public class ShopAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Shop"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                    "Shop_default",
                    "Shop/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}