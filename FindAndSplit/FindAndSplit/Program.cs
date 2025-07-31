using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Collections.Generic;
using System.Drawing;

namespace FindAndSplit
{
    class Program
    {
        static void Main(string[] args)
        {           
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            Dictionary<int, List<RectangleF>> textFound = new Dictionary<int, List<RectangleF>>();
            //Find the text in the PDF document
            loadedDocument.FindText("portable", out textFound);

            PdfDocument document = new PdfDocument();

            //import page based on the find text index
            foreach (int index in textFound.Keys)
            {
                if (textFound[index].Count > 0)
                {
                    document.ImportPage(loadedDocument, index);
                }
            }

            //save the PDF document
            document.Save("portable.pdf");
            //Close the document
            document.Close(true);
            loadedDocument.Close(true);
        }
    }
}
