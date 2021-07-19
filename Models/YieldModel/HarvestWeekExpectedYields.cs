using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models.YieldModel
{
    public class HarvestWeekExpectedYields
    {
        public string plantingWeek { get; set; }
        public string harvestWeek { get; set; }
        public string yields { get; set; }
        public string totalYields { get; set; }
    }
}