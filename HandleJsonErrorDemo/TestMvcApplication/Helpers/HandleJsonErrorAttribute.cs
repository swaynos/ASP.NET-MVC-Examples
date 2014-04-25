using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMvcApplication.Helpers
{
    /// <summary>
    /// This attribute class is used for Json ActionResult methods. When an 
    /// unhandled exception is encountered, it will create a standard Json
    /// response to send back to the client in the following format:
    /// {
    ///     "message": "Message of the Exception",
    ///     "stackTrace": "Stack Trace of the exception"
    /// }
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HandleJsonErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            message = filterContext.Exception.Message,
                            stackTrace = filterContext.Exception.StackTrace
                        }
                    };
                    filterContext.ExceptionHandled = true;

                    // Try this if having problems with IIS sending custom errors
                    //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
            }
        }
    }
}