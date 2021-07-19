using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class IncomeCostModelByCrops
    {
        public string crop { get; set; }
        public double income { get; set; }
        public double costPlant { get; set; }
        public double costLog { get; set; }
        public double costTrans { get; set; }
    }

    public class IncomeCostModelByLocations
    {
        public string location { get; set; }
        public double income { get; set; }
        public double costPlant { get; set; }
        public double costLog { get; set; }
        public double costTrans { get; set; }
        public double incomeAcre { get; set; }
        public double profitAcre { get; set; }
    }

    public class IncomeCostResult
    {
        public double plantCost { get; set; }
        public double laborCost { get; set; }
        public List<IncomeCostModelByCrops> listIncomeCostResult { get; set; }

    }

    public class IncomeCostResultResponse
    {
        public double plantCost { get; set; }
        public double incomes { get; set; }
        public double laborCost { get; set; }
        public List<IncomeCostModelByCrops> listIncomeCostResultByCrops { get; set; }
        public List<IncomeCostModelByLocations> listIncomeCostResultByLocations { get; set; }

    }
}
