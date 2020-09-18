using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class CropsModel
    {
        public int id { get; set; }
        public string abbr_name { get; set; }
        public string crop_name { get; set; }
    }

    public class CropsConfigurationModel {
        public string crop { get; set; }
        public double cplant { get; set; }
        public double pslav { get; set; }
        public double labp { get; set; }
        public double labh { get; set; }
        public string ccrop { get; set; }
        public double dharv { get; set; }
        public double water { get; set; }
        public double minl { get; set; }
        public double maxl { get; set; }
    }
}
