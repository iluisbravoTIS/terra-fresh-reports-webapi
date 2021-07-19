using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models.YieldModel
{
    public class YieldModelResponse
    {
        public YieldInputsModel yieldInputsModel { get; set; }
        public List<HarvestWeekExpectedYields> listHarvestWeekExpectedYields { get; set; }
        public List<PlantingWeekHarvestWeekYields> listPlantingHarvestWeeksYields { get; set; }
    }
}