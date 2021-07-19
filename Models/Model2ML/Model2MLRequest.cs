using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models.Model2ML
{
    public class Model2MLRequest
    {
        public int week { get; set; }
        public List<CropsConfigurationModel> cropsSelected { get; set; }
        public List<LocationsConfigurationModel> locationsSelected { get; set; }
        public List<ContractsModel> contracts { get; set; }
    }
}