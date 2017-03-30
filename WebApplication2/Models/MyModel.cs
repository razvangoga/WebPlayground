using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class MyModel
    {
        public int Item1 { get; set; }
        public int? Item2 { get; set; }

        public List<MyModel> SubModels { get; set; }

        public List<SelectListItem> Items { get; set; }

        public RioMarkers Marker { get; set; } = RioMarkers.NoObjectives;
    }

    public enum RioMarkers
    {
        [Description("No objectives")]
        NoObjectives = 0,
        [Description("A significant objective")]
        ASignificantObjective = 1,
        [Description("The principle objective")]
        ThePrincipalObjective = 2
    }
}
