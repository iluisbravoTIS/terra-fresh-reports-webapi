using System;
using System.Collections.Generic;
using System.Linq;


namespace WebAppReports.Models
{
    public class ModelResultResponse
    {
        public Model1Request objToOtpimize { get; set; }
        public List<PlantResultResponse> listPlantResult { get; set; }
        public List<HarvestResultResponse> listHarvestResult { get; set; }
        public LaborResultResponse listLaborResult { get; set; }
        public IncomeCostResultResponse incomeCostResult { get; set; }
        public bool hasError { get; set; }
        public string messageError { get; set; }
    }
}
