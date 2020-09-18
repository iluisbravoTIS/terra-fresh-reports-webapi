using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppReports.Models;

namespace WebAppReports.Controllers
{    
    public class ReportController : Controller
    {
        [System.Web.Http.HttpPost]
        public ActionResult CreateReport([FromBody] ModelResultResponse modelResult)
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
        public string example([FromBody] string message)
        {
            return message + "LUIS";
        }
    }
}
