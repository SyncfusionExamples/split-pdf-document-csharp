using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByBookmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/PDF_Succinctly.pdf");
            PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;
            Dictionary<PdfPageBase, int> pages = new Dictionary<PdfPageBase, int>();
            Dictionary<string, List<int>> splitRange = new Dictionary<string, List<int>>();

            //iterate all the pages and its index
            for (int i = 0; i < loadedDocument.Pages.Count; i++)
            {
                PdfPageBase page = loadedDocument.Pages[i] as PdfPageBase;
                pages.Add(page, i);
            }

            //Iterate all the bookmarks and it is page range
            for (int i = 0; i < bookmarks.Count; i++)
            {
                if (bookmarks[i].Destination != null)
                {
                    PdfPageBase page = bookmarks[i].Destination.Page;
                    if (pages.ContainsKey(page))
                    {   
                        //Bookmark doesn't have any child bookmark
                        if (bookmarks[i].Count == 0)
                        {
                            int startIndex = pages[page];
                            List<int> range = new List<int>();
                            range.Add(startIndex);
                            range.Add(startIndex);
                            splitRange.Add(bookmarks[i].Title, range);
                        }
                        //Bookmark has child bookmark
                        else
                        {
                            int startIndex = pages[page];
                            int endIndex = startIndex;
                            List<int> range = new List<int>();
                            foreach (PdfLoadedBookmark bookmark in bookmarks[i])
                            {
                                PdfPageBase innerPage = bookmark.Destination.Page;
                                if (pages.ContainsKey(innerPage))
                                {
                                    endIndex = pages[innerPage];
                                }
                            }
                            range.Add(startIndex);
                            range.Add(endIndex);
                            splitRange.Add(bookmarks[i].Title, range);
                        }
                    }
                }
            }

            //Split the PDF document based on the bookmark page range.
            foreach (string title in splitRange.Keys)
            {
                int startIndex = splitRange[title][0];
                int endIndex = splitRange[title][1];
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
