using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitRange
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            //Create new PDF document
            PdfDocument document = new PdfDocument();
            //Import the range of pages from existing PDF
            document.ImportPageRange(loadedDocument, 2,8);
            //Save the new PDF document
            document.Save("PDF_Succinctly.pdf");
            //Close the PDF document
            document.Close(true);
            loadedDocument.Close(true);
        }
    }
}
