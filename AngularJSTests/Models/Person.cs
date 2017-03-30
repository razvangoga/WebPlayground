using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSTests.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Titles Title { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Phone> Phones { get; set; }

        public enum Titles
        {
            None = 0,
            Mrs = 1,
            Mr = 2,
        }

        public enum PhoneType
        {
            Home = 0,
            Work = 1,
            Other = 2
        }

        public class Phone
        {
            public int CountryPrefix { get; set; }
            public string Number { get; set; }
            public PhoneType Type { get; set; }
        }

    }
}