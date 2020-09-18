
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

namespace WebAppReports.Services
{
    public class ReportService
    {
        public byte[] GenerateReportAsync(ModelResultResponse modelResult)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.objToOtpimize)));
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
            ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelResult.incomeCostResult.listIncomeCostResult)));
            ReportDataSource rds6 = new ReportDataSource { Name = "IncomesDataSet", Value = ds.Tables[0] };


            List<string> cropsSelected = new List<string>();

            foreach (CropsConfigurationModel crop in modelResult.objToOtpimize)
            {
                cropsSelected.Add(crop.crop);
            }

            ReportParameter[] parametros =
            {
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

    }
}
