using System;
using System.Collections.Generic;
using System.Linq;


namespace WebAppReports.Models
{
    public class Model1Response
    {
        public Model1Request objToOptimize { get; set; }
        public List<PlantResultResponse> listPlantResult { get; set; }
        public List<HarvestResultResponse> listHarvestResult { get; set; }
        public LaborResultResponse listLaborResult { get; set; }
        public IncomeCostResultResponse incomeCostResult { get; set; }
        public bool hasError { get; set; }
        public string messageError { get; set; }
    }
}
