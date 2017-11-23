using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vsCoreItextsharp.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace vsCoreItextsharp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var pdfFilePath = "./test.pdf";
                var author = "Dummy author";
                var stream = new FileStream(pdfFilePath, FileMode.Create);

                // step 1
                var document = new Document();

                // step 2
                PdfWriter.GetInstance(document, stream);
                // step 3
                document.AddAuthor(author);
                document.Open();
                // step 4
                document.Add(new Paragraph(text));

                document.Close();
                stream.Dispose();
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
