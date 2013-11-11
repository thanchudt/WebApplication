using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Common
{
    public class MyRazorViewEngines : RazorViewEngine
    {
        public MyRazorViewEngines()
            : base()
        {
            var viewLocationFormats = new List<string>
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/{1}/{0}.vbhtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/Views/Shared/{0}.vbhtml"
                };
            var areaViewLocationFormats = new List<string>
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                };

            ViewLocationFormats = viewLocationFormats.ToArray();
            MasterLocationFormats = viewLocationFormats.ToArray();
            PartialViewLocationFormats = viewLocationFormats.ToArray();

            AreaMasterLocationFormats = areaViewLocationFormats.ToArray();
            AreaPartialViewLocationFormats = areaViewLocationFormats.ToArray();
            AreaViewLocationFormats = areaViewLocationFormats.ToArray();
              
        }
    }
}