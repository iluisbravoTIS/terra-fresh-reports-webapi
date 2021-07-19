using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models
{
    public class ContractsModel
    {
        public int weeks { get; set; }
        public string prod { get; set; }
        public string cust { get; set; }
        public double dem2 { get; set; }
        public double price { get; set; }
    }

    public class LandAvailableModel
    {
        public double land { get; set; }
        public string location { get; set; }
    }

    public class ContractsModelResponse
    {
        public List<LandAvailableModel> listLandAvailableResult { get; set; }
        public List<CropsConfigurationModel> cropsSelected { get; set; }
        public List<ContractsResult> listContractsResult { get; set; }       
    }

    public class ContractsResult
    {
        public string location { get; set; }
        public string crop { get; set; }
        public string ccrop { get; set; }
        public double data { get; set; }
        public int week { get; set; }
        public string dateInit { get; set; }
        public string dateRange { get; set; }
        public double spot { get; set; }
        public double demand { get; set; }
    }




}