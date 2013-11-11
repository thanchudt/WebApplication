using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Common
{
    public class MyViewEngines : RazorViewEngine
    {
        public MyViewEngines()
        {            
            var areaMasterLocationFormats = new List<string>
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };
            AreaMasterLocationFormats = areaMasterLocationFormats.ToArray();
            AreaPartialViewLocationFormats = areaMasterLocationFormats.ToArray();
            AreaViewLocationFormats = areaMasterLocationFormats.ToArray();
              
        }
    }
}