using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Filters
{
    public class Localization : ActionFilterAttribute
    {
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;

            HttpCookie cultureCookie = filterContext.RequestContext.HttpContext.Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;

                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
        }

    }
}