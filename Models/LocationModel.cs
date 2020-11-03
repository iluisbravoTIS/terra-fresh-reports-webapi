using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models
{
    public class LocationModel
    {
    }

    public class LocationsConfigurationModel
    {
        public string id { get; set; }
        public string location { get; set; }
        public string abbr { get; set; }
        public int la { get; set; }
        public double m { get; set; }
        public double w { get; set; }
        public double clabor { get; set; }
        public double ctemp { get; set; }
        public double chire { get; set; }
        public double mtemp { get; set; }
        public double mfix { get; set; }
        public double maxi { get; set; }
    }
}