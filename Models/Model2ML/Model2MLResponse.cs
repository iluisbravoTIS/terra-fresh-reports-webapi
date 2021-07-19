using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReports.Models.Model2ML
{
    public class Model2MLResponse
    {
        public Model2MLRequest objToOptimize { get; set; }
        public List<PlantResultResponse> listPlantResult { get; set; }
        public List<HarvestResultResponse> listHarvestResult { get; set; }
        public LaborResultResponse listLaborResult { get; set; }
        public IncomeCostResultResponse incomeCostResult { get; set; }
        public ContractsModelResponse ContractsResult { get; set; }
        public bool hasError { get; set; }
        public string messageError { get; set; }
    }
}