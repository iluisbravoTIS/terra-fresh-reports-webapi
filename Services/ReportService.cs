
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WebAppReports.Models;
using System.Web.Mvc;
using WebAppReports.Models.Model2ML;
using Newtonsoft.Json.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using WebAppReports.Models.YieldModel;

namespace WebAppReports.Services
{
    public class ReportService
    {
        public byte[] GenerateReportAsync(Model1Response modelResult)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.objToOptimize.cropsSelected)));
            ReportDataSource rds1 = new ReportDataSource { Name = "CropsToOptimizeDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listPlantResult)));
            ReportDataSource rds2 = new ReportDataSource { Name = "PlantDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listHarvestResult)));
            ReportDataSource rds3 = new ReportDataSource { Name = "HarvestDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listLaborResult.listLaborPerWeeks)));
            ReportDataSource rds4 = new ReportDataSource { Name = "LaborDataSet2", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listLaborResult.listLaborRequirementSummary)));
            ReportDataSource rds5 = new ReportDataSource { Name = "LaborDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.incomeCostResult.listIncomeCostResultByCrops)));
            ReportDataSource rds6 = new ReportDataSource { Name = "IncomesDataSet", Value = ds.Tables[0] };


            List<string> cropsSelected = new List<string>();

            foreach (CropsConfigurationModel crop in modelResult.objToOptimize.cropsSelected)
            {
                cropsSelected.Add(crop.crop);
            }

            string locationSelected = modelResult.objToOptimize.locationSelected.location;

            ReportParameter[] parametros =
            {
                new ReportParameter("locationSelected", locationSelected),
                new ReportParameter("cropsSelected", String.Join(", ", cropsSelected)),
                new ReportParameter("incomes", modelResult.incomeCostResult.incomes.ToString()),
                new ReportParameter("plantingCost", modelResult.incomeCostResult.plantCost.ToString()),
                new ReportParameter("laborCost", modelResult.incomeCostResult.laborCost.ToString())
            };

            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\ReportResultData.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Report Result Data.pdf";

            lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);
            lr.DataSources.Add(rds2);
            lr.DataSources.Add(rds3);
            lr.DataSources.Add(rds4);
            lr.DataSources.Add(rds5);
            lr.DataSources.Add(rds6);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        public byte[] GenerateYieldModelReportAsync(YieldModelResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listHarvestWeekExpectedYields)));
            ReportDataSource rds1 = new ReportDataSource { Name = "YieldModelDS2", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listPlantingHarvestWeeksYields)));
            ReportDataSource rds2 = new ReportDataSource { Name = "YieldModelDS1", Value = ds.Tables[0] };

            ReportParameter[] parametros =
            {
                new ReportParameter("initPlantingWeek", modelResult.yieldInputsModel.startPWDate.ToString()),
                new ReportParameter("endPlantingWeek", modelResult.yieldInputsModel.endPWDate.ToString()),
                new ReportParameter("numbersOfWeeks", modelResult.yieldInputsModel.startPW.ToString() + " - " + modelResult.yieldInputsModel.endPW.ToString()),
                new ReportParameter("state", modelResult.yieldInputsModel.state.ToString()),
                new ReportParameter("zipCode", modelResult.yieldInputsModel.city.ToString()),
                new ReportParameter("tempScenario", modelResult.yieldInputsModel.tempScenario.ToString()),
                new ReportParameter("harvestRate", modelResult.yieldInputsModel.harvestRate.ToString()),
                new ReportParameter("minimalHarvestWet", modelResult.yieldInputsModel.minimalHarvest.ToString()),
                new ReportParameter("standardYield", modelResult.yieldInputsModel.standartYield.ToString()),
                new ReportParameter("minimumStandardYield", modelResult.yieldInputsModel.percentStandardYield.ToString()),
                new ReportParameter("minimumTime", modelResult.yieldInputsModel.minimumTime.ToString()),
                new ReportParameter("maximumHarvestTime", modelResult.yieldInputsModel.maximumHarvestTime.ToString()),
                new ReportParameter("crop", modelResult.yieldInputsModel.crop.ToString())
            };

            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\YieldModelResults.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Yield Model Results.pdf";

            lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);
            lr.DataSources.Add(rds2);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        public byte[] GenerateYieldModelReport2Async(YieldModelResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listPlantingHarvestWeeksYields)));
            ReportDataSource rds1 = new ReportDataSource { Name = "HeatTableDT", Value = ds.Tables[0] };

            ReportParameter[] parametros =
            {};

            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\YieldModelResultHeatTable.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Yield Model Results.pdf";

            lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }


        public byte[] GenerateScenarioConfigurationReportAsync(Model2MLResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.objToOptimize.cropsSelected)));
            ReportDataSource rds1 = new ReportDataSource { Name = "CropsToOptimizeDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.objToOptimize.locationsSelected)));
            ReportDataSource rds2 = new ReportDataSource { Name = "LocationsToOptimizeDataSet", Value = ds.Tables[0] };

            List<string> cropsSelected = new List<string>();
            foreach (CropsConfigurationModel crop in modelResult.objToOptimize.cropsSelected)
            {
                cropsSelected.Add(crop.crop);
            }

            //string locationSelected = modelResult.objToOptimize.locationSelected.;
            List<string> locationSelected = new List<string>();
            foreach (LocationsConfigurationModel location in modelResult.objToOptimize.locationsSelected)
            {
                locationSelected.Add(location.location);
            }

            ReportParameter[] parametros =
            {
                new ReportParameter("locationSelected", String.Join(", ", locationSelected)),
                new ReportParameter("cropsSelected", String.Join(", ", cropsSelected))
            };

            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\ScenarioConfiguration.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Scenario Configuration.pdf";

            lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);
            lr.DataSources.Add(rds2);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        public byte[] GenerateEconomicAnalysisReportAsync(Model2MLResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.incomeCostResult.listIncomeCostResultByCrops)));
            ReportDataSource rds1 = new ReportDataSource { Name = "IncomesByCropsDataSet", Value = ds.Tables[0] };

            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.incomeCostResult.listIncomeCostResultByLocations)));
            ReportDataSource rds2 = new ReportDataSource { Name = "IncomesByLocationsDataSet", Value = ds.Tables[0] };

            ReportParameter[] parametros =
            {
                new ReportParameter("incomes", modelResult.incomeCostResult.incomes.ToString()),
                new ReportParameter("plantingCost", modelResult.incomeCostResult.plantCost.ToString()),
                new ReportParameter("laborCost", modelResult.incomeCostResult.laborCost.ToString())
            };

            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\EconomicAnalysis.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Economic Analysis.pdf";

            lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);
            lr.DataSources.Add(rds2);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        public byte[] GenerateContractsResponseReportAsync(Model2MLResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.ContractsResult.listLandAvailableResult)));
            ReportDataSource rds1 = new ReportDataSource { Name = "LandAvailableDataSet", Value = ds.Tables[0] };
            
            LocalReport lr = new LocalReport();
            var Reportpath = @".\Reports\ContractHead.rdlc";
            lr.ReportPath = Reportpath;
            lr.DisplayName = "Contract Response.pdf";

            //lr.SetParameters(parametros);
            lr.DataSources.Add(rds1);
            //lr.DataSources.Add(rds2);

            var reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            //return renderedBytes;

            List<string> cropsSelected = new List<string>();
            int indexContent = 0;
            foreach (CropsConfigurationModel crop in modelResult.ContractsResult.cropsSelected)
            {
                cropsSelected.Add(crop.crop);
            }

            List<byte[]> docs = new List<byte[]>();
            docs.Add(renderedBytes);

            cropsSelected.ForEach(c => {
                indexContent++;
                DataSet ds2 = new DataSet();
                ds2 = new DataSet();
                ds2.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.ContractsResult.listContractsResult.FindAll(lcr => lcr.crop == c))));
                ReportDataSource rds2 = new ReportDataSource { Name = "ContractForCropByLocationsDataSet", Value = ds2.Tables[0] };


                ReportParameter[] parametros =
                {
                    new ReportParameter("cropSelected", c),
                    new ReportParameter("indexContent", indexContent.ToString())
                };

                lr = new LocalReport();
                Reportpath = @".\Reports\ContractByCrop.rdlc";
                lr.ReportPath = Reportpath;
                lr.DisplayName = "Contract Response.pdf";

                lr.SetParameters(parametros);
                lr.DataSources.Add(rds2);

                var reportType2 = "pdf";
                string mimeType2;
                string encoding2;
                string fileNameExtension2;
                Warning[] warnings2;
                string[] streams2;
                renderedBytes = lr.Render(reportType2, null, out mimeType2, out encoding2, out fileNameExtension2, out streams2, out warnings2);
               
                 docs.Add(renderedBytes);
            });

            byte[] final = docs.SelectMany(a => a).ToArray();

            return concatAndAddContent(docs);
        }

        public byte[] GeneratePlantingDecisionsReportAsync(Model2MLResponse modelResult)
        {
            List<string> locationSelected = new List<string>();
            foreach (LocationsConfigurationModel location in modelResult.objToOptimize.locationsSelected)
            {
                locationSelected.Add(location.location);
            }

            List<byte[]> docs = new List<byte[]>();

            locationSelected.ForEach(location =>
            {
                DataSet ds = new DataSet();
                ds = new DataSet();
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listPlantResult.FindAll(lp => lp.location == location))));
                ReportDataSource rds = new ReportDataSource { Name = "PlantDataSet", Value = ds.Tables[0] };

                ReportParameter[] parametros =
                {
                    new ReportParameter("locationSelected", location)
                };

                LocalReport lr = new LocalReport();
                var Reportpath = @".\Reports\PlantingDecisions.rdlc";
                lr.ReportPath = Reportpath;
                lr.DisplayName = "Planting Decisions.pdf";

                lr.SetParameters(parametros);
                lr.DataSources.Add(rds);

                var reportType = "pdf";
                string mimeType;
                string encoding;
                string fileNameExtension;
                Warning[] warnings;
                string[] streams;
                var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                //return renderedBytes;
                docs.Add(renderedBytes);
            });

            byte[] final = docs.SelectMany(a => a).ToArray();

            return concatAndAddContent(docs);

        }

        public byte[] GenerateExpectedHarvestingReportAsync(Model2MLResponse modelResult)
        {
            List<string> locationSelected = new List<string>();
            foreach (LocationsConfigurationModel location in modelResult.objToOptimize.locationsSelected)
            {
                locationSelected.Add(location.location);
            }

            List<byte[]> docs = new List<byte[]>();

            locationSelected.ForEach(location =>
            {
                DataSet ds = new DataSet();
                ds = new DataSet();
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listHarvestResult.FindAll(lp => lp.location == location))));
                ReportDataSource rds = new ReportDataSource { Name = "HarvestDataSet", Value = ds.Tables[0] };

                ReportParameter[] parametros =
                {
                    new ReportParameter("locationSelected", location)
                };

                LocalReport lr = new LocalReport();
                var Reportpath = @".\Reports\ExpectedHarvesting.rdlc";
                lr.ReportPath = Reportpath;
                lr.DisplayName = "Expected Harvesting.pdf";

                lr.SetParameters(parametros);
                lr.DataSources.Add(rds);

                var reportType = "pdf";
                string mimeType;
                string encoding;
                string fileNameExtension;
                Warning[] warnings;
                string[] streams;
                var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                //return renderedBytes;
                docs.Add(renderedBytes);
            });

            byte[] final = docs.SelectMany(a => a).ToArray();

            return concatAndAddContent(docs);

        }

        public byte[] GenerateLaborResultReportAsync(Model2MLResponse modelResult)
        {
            List<string> locationSelected = new List<string>();
            foreach (LocationsConfigurationModel location in modelResult.objToOptimize.locationsSelected)
            {
                locationSelected.Add(location.location);
            }

            List<byte[]> docs = new List<byte[]>();

            locationSelected.ForEach(location =>
            {
                DataSet ds = new DataSet();
                ds = new DataSet();
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listLaborResult.listLaborPerWeeks.FindAll(lp => lp.location == location))));
                ReportDataSource rds = new ReportDataSource { Name = "LaborDataSet2", Value = ds.Tables[0] };

                ds = new DataSet();
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.listLaborResult.listLaborRequirementSummary.FindAll(lp => lp.location == location))));
                ReportDataSource rds2 = new ReportDataSource { Name = "LaborDataSet", Value = ds.Tables[0] };

                ReportParameter[] parametros =
                {
                    new ReportParameter("locationSelected", location)
                };

                LocalReport lr = new LocalReport();
                var Reportpath = @".\Reports\LaborResult.rdlc";
                lr.ReportPath = Reportpath;
                lr.DisplayName = "Labor Result.pdf";

                lr.SetParameters(parametros);
                lr.DataSources.Add(rds);
                lr.DataSources.Add(rds2);

                var reportType = "pdf";
                string mimeType;
                string encoding;
                string fileNameExtension;
                Warning[] warnings;
                string[] streams;
                var renderedBytes = lr.Render(reportType, null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                //return renderedBytes;
                docs.Add(renderedBytes);
            });

            byte[] final = docs.SelectMany(a => a).ToArray();

            return concatAndAddContent(docs);

        }

        public static byte[] concatAndAddContent(List<byte[]> pdfByteContent)
        {

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var copy = new PdfSmartCopy(doc, ms))
                    {
                        doc.Open();

                        //Loop through each byte array
                        foreach (var p in pdfByteContent)
                        {

                            //Create a PdfReader bound to that byte array
                            using (var reader = new PdfReader(p))
                            {

                                //Add the entire document instead of page-by-page
                                copy.AddDocument(reader);
                            }
                        }

                        doc.Close();
                    }
                }

                //Return just before disposing
                return ms.ToArray();
            }
        }


    }
}
