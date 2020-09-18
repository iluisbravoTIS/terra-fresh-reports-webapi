using System;
using System.Collections.Generic;
using System.Linq;


namespace WebAppReports.Models
{
    public class ModelResult
    {
        public List<CropsConfigurationModel> objToOtpimize { get; set; }
        public List<PlantResult> listPlantResult { get; set; }
        public List<HarvestResult> listHarvestResult { get; set; }
        public List<OPLResult> listOPLResult { get; set; }
        public List<HireResult> listHireResult { get; set; }
        public List<FireResult> listFireResult { get; set; }
        public List<OPTResult> listOPTResult { get; set; }
        public IncomeCostResult incomeCostResult { get; set; }
        public bool hasError { get; set; }
        public string messageError { get; set; }
    }

    public class ModelResultResponse
    {
        public List<CropsConfigurationModel> objToOtpimize { get; set; }
        public List<PlantResultResponse> listPlantResult { get; set; }
        public List<HarvestResultResponse> listHarvestResult { get; set; }
        public LaborResultResponse listLaborResult { get; set; }
        public IncomeCostResultResponse incomeCostResult { get; set; }
        public bool hasError { get; set; }
        public string messageError { get; set; }
    }
}
