using MVC_DateTime_POST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MVC_DateTime_POST.Infrastructure;

namespace MVC_DateTime_POST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Get()
        {
            DateTime now1 = DateTime.UtcNow;
            DateTime now2 = DateTime.Now.AddHours(-12);

            return this.Json(new
            {
                D1 = now1,
                D2 = now2,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Post(DateModel viewModel)
        {
            return this.Json(new { status = "ok", viewModel = viewModel }, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            //return base.Json(data, contentType, contentEncoding, behavior);
            return new JsonNetResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}