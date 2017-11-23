using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using iTextSharp.text.pdf;

namespace OpenXMLSDKTableExport.Services
{
    public static class CreateFile
    {
        public static void Word(string filepath, string printData)
        {
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run = para.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(printData));
            }
        }

        public static void Xlsx(string filepath,string printData)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employees" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();

                row.Append(new Cell() { CellValue = new CellValue(printData), DataType = new EnumValue<CellValues>(CellValues.String) });

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();
            }
        }

        public static void Pdf(string filepath,string printData)
        {

            //simple file write check

            //using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(pdfFilePath, true))
            //{
            //    file.WriteLine("Fourth line");
            //}


            var author = "Dummy author";
            var stream = new FileStream(filepath, FileMode.Create);

            // step 1
            var document = new iTextSharp.text.Document();

            // step 2
            PdfWriter.GetInstance(document, stream);
            // step 3
            document.AddAuthor(author);
            document.Open();
            // step 4
            document.Add(new iTextSharp.text.Paragraph(printData));

            document.Close();
            stream.Dispose();
        }
    }
}
