using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppReports.Models
{
    public class DocumentResponseModel
    {
        public bool hasError { get; set; }
        public string messageError { get; set; }
        public ActionResult document { get; set; }
    }
}