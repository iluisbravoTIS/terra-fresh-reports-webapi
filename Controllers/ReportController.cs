using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppReports.Models;
using WebAppReports.Models.Model2ML;
using WebAppReports.Models.YieldModel;

namespace WebAppReports.Controllers
{    
    public class ReportController : Controller
    {
        [System.Web.Http.HttpPost]
        public ActionResult CreateReport([FromBody] Model1Response modelResult)
        {          

            try
            {
                var _reportService = new Services.ReportService();
                var returnString = _reportService.GenerateReportAsync(modelResult);
                ActionResult document = File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, "Report Result Data.pdf");


                DocumentResponseModel response = new DocumentResponseModel()
                {
                    hasError = false,
                    messageError = null,
                    document = document
                };

                return Content(JsonConvert.SerializeObject(response), "application/json");
            }
            catch (Exception ex)
            {
                DocumentResponseModel response = new DocumentResponseModel()
                {
                    hasError = true,
                    messageError = ex.Message,
                    document = null
                };
                return Content(JsonConvert.SerializeObject(response), "application/json");
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult CreateReportYieldModel([FromBody] YieldModelResponse modelResult)
        {

            try
            {
                var _reportService = new Services.ReportService();
                var rpt1 = _reportService.GenerateYieldModelReportAsync(modelResult);
                var rpt2 = _reportService.GenerateYieldModelReport2Async(modelResult);


                using (MemoryStream ms = new MemoryStream())
                {
                    using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        var zipArchiveEntry = archive.CreateEntry("1. Input Parameters and Expected Yields .pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(rpt1, 0, rpt1.Length);
                        zipArchiveEntry = archive.CreateEntry("2. Heat Table of Obtained Harvest.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(rpt2, 0, rpt2.Length);

                    }
                    //return File(ms.ToArray(), "application/zip", "Result Data.zip");

                    ActionResult document = File(ms.ToArray(), "application/zip", "Yield Model Results.zip");

                    DocumentResponseModel response = new DocumentResponseModel()
                    {
                        hasError = false,
                        messageError = null,
                        document = document
                    };

                    return Content(JsonConvert.SerializeObject(response), "application/json");
                }

            }
            catch (Exception ex)
            {
                DocumentResponseModel response = new DocumentResponseModel()
                {
                    hasError = true,
                    messageError = ex.Message,
                    document = null
                };
                return Content(JsonConvert.SerializeObject(response), "application/json");
            }
        }


        [System.Web.Http.HttpPost]
        public ActionResult CreateReportModel2ML([FromBody] Model2MLResponse modelResult)
        {

            try
            {

                var _reportService = new Services.ReportService();
                var scenarioConfigurationBytesReport = _reportService.GenerateScenarioConfigurationReportAsync(modelResult);
                //ActionResult document = File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, "Scenario Configuration.pdf");

                var economicAnalysisBytesReport = _reportService.GenerateEconomicAnalysisReportAsync(modelResult);
                //ActionResult documentEA = File(returnString2, System.Net.Mime.MediaTypeNames.Application.Octet, "Economic Analysis.pdf");

                var contractResponseBytesReport = _reportService.GenerateContractsResponseReportAsync(modelResult);

                var plantingDecisionsBytesReport = _reportService.GeneratePlantingDecisionsReportAsync(modelResult);

                var expectedHarvestingBytesReport = _reportService.GenerateExpectedHarvestingReportAsync(modelResult);

                var laborResultBytesReport = _reportService.GenerateLaborResultReportAsync(modelResult);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        var zipArchiveEntry = archive.CreateEntry("1.Scenario Configuration.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(scenarioConfigurationBytesReport, 0, scenarioConfigurationBytesReport.Length);
                        zipArchiveEntry = archive.CreateEntry("2.Economic Analysis.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(economicAnalysisBytesReport, 0, economicAnalysisBytesReport.Length);
                        zipArchiveEntry = archive.CreateEntry("3.Contract Response.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(contractResponseBytesReport, 0, contractResponseBytesReport.Length);
                        zipArchiveEntry = archive.CreateEntry("4.Planting Decisions.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(plantingDecisionsBytesReport, 0, plantingDecisionsBytesReport.Length);
                        zipArchiveEntry = archive.CreateEntry("5.Expected Harvesting.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(expectedHarvestingBytesReport, 0, expectedHarvestingBytesReport.Length);
                        zipArchiveEntry = archive.CreateEntry("6.Labor Result.pdf", CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(laborResultBytesReport, 0, laborResultBytesReport.Length);
                    }
                    //return File(ms.ToArray(), "application/zip", "Result Data.zip");

                    ActionResult document = File(ms.ToArray(), "application/zip", "Result Data.zip");

                    DocumentResponseModel response = new DocumentResponseModel()
                    {
                        hasError = false,
                        messageError = null,
                        document = document
                    };

                    return Content(JsonConvert.SerializeObject(response), "application/json");
                }

            }
            catch (Exception ex)
            {
                DocumentResponseModel response = new DocumentResponseModel()
                {
                    hasError = true,
                    messageError = ex.Message,
                    document = null
                };
                return Content(JsonConvert.SerializeObject(response), "application/json");
            }
        }

        [System.Web.Http.HttpPost]
        public string example([FromBody] string message)
        {
            return message + "LUIS";
        }
    }
}
