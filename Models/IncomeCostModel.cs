using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class IncomeCostModel
    {
        public string crop { get; set; }
        public double income { get; set; }
        public double costPlant { get; set; }
        public double costLog { get; set; }
        public double costTrans { get; set; }
    }

    public class IncomeCostResult
    {
        public double plantCost { get; set; }
        public double laborCost { get; set; }
        public List<IncomeCostModel> listIncomeCostResult { get; set; }

    }

    public class IncomeCostResultResponse
    {
        public double plantCost { get; set; }
        public double incomes { get; set; }
        public double laborCost { get; set; }
        public List<IncomeCostModel> listIncomeCostResult { get; set; }

    }
}
