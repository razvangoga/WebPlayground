using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaTests.Areas.v1.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: v1/Application
        public ActionResult Index()
        {
            return View();
        }
    }
}