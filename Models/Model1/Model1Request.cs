using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models
{
    public class Model1Request
    {
        public int week { get; set; }
        public LocationsConfigurationModel locationSelected { get; set; }
        public List<CropsConfigurationModel> cropsSelected { get; set; }
    }
}