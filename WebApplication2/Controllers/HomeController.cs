using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MyModel mm = new MyModel()
            {
                Item1 = 4,
                Item2 = 3,
                SubModels = Enumerable.Range(1, 5).Select(i => new MyModel()
                {
                    Item1 = i,
                    Item2 = i,
                    //Items = Enumerable.Range(0, 10).Select(ii => new SelectListItem()
                    //{
                    //    Text = ii.ToString(),
                    //    Value = ii.ToString(),
                    //    Selected = i == ii
                    //}).ToList()
                }).ToList(),
                Items = Enumerable.Range(0, 10).Select(i => new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                }).ToList(),
                Marker = RioMarkers.ASignificantObjective
            };

            return View(mm);
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
    }
}