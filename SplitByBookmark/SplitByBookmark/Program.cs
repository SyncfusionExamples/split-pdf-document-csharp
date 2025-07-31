using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System.Collections.Generic;

namespace SplitByBookmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");

            //Get the bookmarks from the PDF document
            PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;

            //Create a dictionary to hold the pages and its index
            Dictionary<string, int[]> splitRange = new Dictionary<string, int[]>();

            //Iterate all the bookmarks and it is page range
            for (int i = 0; i < bookmarks.Count; i++)
            {
                PdfLoadedBookmark bookmark = bookmarks[i] as PdfLoadedBookmark;
                if (bookmark.Destination != null)
                {
                    int startIndex = bookmark.Destination.PageIndex;
                    int endIndex = startIndex;

                    // If bookmark has child bookmarks, set endIndex to the last child's page index
                    if (bookmark.Count > 0)
                    {
                        foreach (PdfLoadedBookmark child in bookmark)
                        {
                            if (child.Destination != null)
                                endIndex = child.Destination.PageIndex;
                        }
                    }
                    splitRange[bookmark.Title] = new[] { startIndex, endIndex };
                }
            }

            //Split the PDF document based on the bookmark page range.
            foreach (var sRange in splitRange)
            {
                string title = sRange.Key;
                int startIndex = sRange.Value[0];
                int endIndex = sRange.Value[1];

                //Create a new PDF document.
                PdfDocument document = new PdfDocument();
                //Import the pages to the new PDF document.
                document.ImportPageRange(loadedDocument, startIndex, endIndex);
                //Save the document in a specified folder.
                document.Save(title + ".pdf");
                //Close the document.
                document.Close(true);
            }
            loadedDocument.Close(true);
        }
    }
}
