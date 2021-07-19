using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models.YieldModel
{
    public class YieldModel
    {

    }
    public class YieldInputsModel
    {
        public string state { get; set; }
        public string crop { get; set; }
        public int city { get; set; }
        public string tempScenario { get; set; }
        public DateTime startPWDate { get; set; }
        public DateTime endPWDate { get; set; }
        public int startPW { get; set; }
        public int endPW { get; set; }
        public double? harvestRate { get; set; }
        public double? minimalHarvest { get; set; }
        public double? standartYield { get; set; }
        public double? percentStandardYield { get; set; }
        public double? minimumTime { get; set; }
        public double? maximumHarvestTime { get; set; }
    }
}