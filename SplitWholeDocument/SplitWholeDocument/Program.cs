using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWholeDocument
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Load PDF document
            PdfLoadedDocument document = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            //Split PDF document with pattern
            document.Split("Document-{0}.pdf",);
            //Close the document
            document.Close(true);
        }
    }
}
