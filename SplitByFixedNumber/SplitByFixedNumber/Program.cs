using Syncfusion.Pdf.Parsing;

namespace SplitByFixedNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            //Split the pages into fixed number
            loadedDocument.SplitByFixedNumber("Output-{0}.pdf", 2);
            //close the document
            loadedDocument.Close(true);
        }
    }
}
