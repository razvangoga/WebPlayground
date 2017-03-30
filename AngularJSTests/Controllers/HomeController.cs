using AngularJSTests.Infrastructure;
using AngularJSTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSTests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Titles = this.GetAllValuesListInt<Person.Titles>();
            this.ViewBag.PhoneTypes = this.GetAllValuesListInt<Person.PhoneType>();

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

        public JsonResult GetPerson()
        {
            Person person = new Person()
            {
                Name = "Razvan Goga",
                Title = Person.Titles.Mr,
                BirthDate = new DateTime(1984, 02, 26),
                Address = "Dorotheenstr 19, Dusseldorf",
                Phones = new List<Person.Phone>()
                {
                    new Person.Phone()
                    {
                        CountryPrefix = 40,
                        Number = "0724507457",
                        Type = Person.PhoneType.Home
                    },
                    new Person.Phone()
                    {
                        CountryPrefix = 49,
                        Number = "123456789",
                        Type = Person.PhoneType.Work
                    }
                }
            };

            return this.Json(person, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SavePerson(Person person)
        {
            return this.Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetAllValuesListInt<TEnum>(string name = null)
             where TEnum : struct, IConvertible
        {
            return EnumExtensions.GetAllValuesListInt<TEnum>(name).Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Key.ToString()
            }).ToList();
        }
    }
}