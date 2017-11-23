using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenXMLSDKTableExport.Models;
using OpenXMLSDKTableExport.Services;

namespace OpenXMLSDKTableExport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string printData)
        {
            ViewData["TextToShow"] = string.IsNullOrEmpty(printData)?  "dummy text to show": printData;
            CreateFile.Word("./test.doc", ViewData["TextToShow"].ToString());
            CreateFile.Xlsx("./test.xlsx", ViewData["TextToShow"].ToString());
            CreateFile.Pdf("./test.pdf", ViewData["TextToShow"].ToString());
            return View();
        }


        public IActionResult Word()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("./test.doc");
            return File(fileBytes, "application/x-msdownload", "test.doc");
        }

        public IActionResult Xlsx()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("./test.xlsx");
            return File(fileBytes, "application/x-msdownload", "test.xlsx");
        }

        public IActionResult Pdf()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("./test.pdf");
            return File(fileBytes, "application/x-msdownload", "test.pdf");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
