using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class PlantResult
    {
        public string crop { get; set; }
        public int week { get; set; }
        public string location { get; set; }
        public double acres { get; set; }

    }

    public class PlantResultResponse
    {
        public string crops { get; set; }
        public int weeks { get; set; }
        public string dateRange { get; set; }
        public string dateInit { get; set; }
        public double acres { get; set; }
        public string location { get; set; }

    }
}
