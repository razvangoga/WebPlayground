using ErrorHandling.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
#if DEBUG
            ViewBag.Message = "Compiled in DEBUG";
#else
            ViewBag.Message = "Compiled in RELEASE";
#endif

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Crash()
        {
            ViewBag.Message = "A page that crashes.";

            throw new Exception("some critical crash has happened here....");

            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {
                var exception = filterContext.Exception;
                if (!(exception is HttpException)) //ignore "file not found"
                    SimpleLogger.Error($"OnException - {Request.Url}", exception);
            }
            finally
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = RedirectToAction("Error", "Home");
            }
        }
    }
}