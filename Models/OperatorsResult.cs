using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReports.Models
{
    public class OperatorsResult
    {

    }

    public class OPFResult
    {
        public int week { get; set; }
        public string facility { get; set; }
        public double operatorsHoursRequired { get; set; }

    }

    public class OPLResult
    {
        public int week { get; set; }
        public string location { get; set; }
        public double operatorsRequired { get; set; }

    }

    public class HireResult
    {
        public int week { get; set; }
        public string location { get; set; }
        public double operatorsToHire { get; set; }

    }

    public class FireResult
    {
        public int week { get; set; }
        public string location { get; set; }
        public double operatorsToFire { get; set; }

    }

    public class OPTResult
    {
        public int week { get; set; }
        public string location { get; set; }
        public double temporalOperatorsHired { get; set; }

    }

    public class LaborResultResponse
    {
        public List<LaborPerWeeksResponse> listLaborPerWeeks { get; set; }
        public List<LaborRequirementSummaryResponse> listLaborRequirementSummary { get; set; }

    }

    public class LaborPerWeeksResponse
    {
        public int weeks { get; set; }
        public string dateRange { get; set; }
        public string dateInit { get; set; }
        public int labors { get; set; }
        public string laborType { get; set; }
    }

    public class LaborRequirementSummaryResponse
    {
        public int weeks { get; set; }
        public string dateRange { get; set; }
        public double totalLaborRequired { get; set; }
        public double laborHired { get; set; }
        public double laborFired { get; set; }
        public double permanentLaborAvailable { get; set; }
        public double temporaryLaborHired { get; set; }
        public double totalLaborAvailable { get; set; }

    }
}
