using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Areas.WorldMap
{
    public class WorldMapAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "WorldMap"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                    "WorldMap_default",
                    "WorldMap/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}