using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPDFWithMultiplePage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            
            //Split the PDF documents each contains only 2 pages
            for (int i = 0; i < loadedDocument.Pages.Count; i = i + 2)
            {
                //Create new PDF document
                PdfDocument document = new PdfDocument();
                //Import the particular page from an existing PDF
                document.ImportPageRange(loadedDocument, i,i+1);
                //Save the new PDF document
                document.Save("PDF_Succinctly-"+i+".pdf");
                //Close the PDF document
                document.Close(true);

            }
            loadedDocument.Close(true);

        }
    }
}
