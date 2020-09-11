using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitParticularPage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            //Create new PDF document
            PdfDocument document = new PdfDocument();
            //Import the particular page from existing PDF
            document.ImportPage(loadedDocument, 8);
            //Save the new PDF document
            document.Save("PDF_Succinctly8.pdf");
            //Close the PDF document
            document.Close(true);
            loadedDocument.Close(true);

        }
    }
}

