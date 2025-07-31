using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace ImportAccessibilityTags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/Tagged_PDF.pdf");
            //Create the split options object.
            PdfSplitOptions splitOptions = new PdfSplitOptions();
            //Enable the Split tags property.
            splitOptions.SplitTags = true;
            //Split the document by ranges.
            loadedDocument.SplitByFixedNumber("Output{0}.pdf", 1, splitOptions);
            //Close the document.
            loadedDocument.Close(true);
        }
    }
}
