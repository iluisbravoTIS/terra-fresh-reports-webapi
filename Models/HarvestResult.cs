using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class HarvestResult
    {       
        public string crop { get; set; }
        public int weekp { get; set; }
        public int weekh { get; set; }
        public string location { get; set; }
        public double pounds { get; set; }
    }

    public class HarvestResultResponse
    {
        public string crops { get; set; }
        public int weeks { get; set; }
        public string dateRange { get; set; }
        public string dateInit { get; set; }
        public double pounds { get; set; }
    }
}
