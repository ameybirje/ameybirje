using System.Web.Mvc;
using System.Configuration;
using System.Web;
using System;

namespace RohiniTravels.Web.Common
{
    public class Filters : ActionFilterAttribute , IExceptionFilter
    {
        public Filters()
        {
            traceException = true;
        }

        public string sessionval { get; set; }

        public bool traceException { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);   
        }

        public void OnException(ExceptionContext filterContext)
        {
            //string fileName = CommonMethods.GetDate() + ".txt";
            //string filePath = ConfigurationManager.AppSettings["ErrorFilePath"];
            //string msg = "\n" + filterContext.RouteData.Values["controller"] + " => " +
            //     filterContext.RouteData.Values["action"] + "\t" + filterContext.Exception.Message + "\t" + DateTime.UtcNow.AddHours(5).AddMinutes(30)
            //      + "\n" + "------------------------------------------------------------------------------------------";


            //if (traceException)
            //    CommonMethods.LogException(HttpContext.Current.Server.MapPath(filePath + fileName), msg);
        }

    }
}