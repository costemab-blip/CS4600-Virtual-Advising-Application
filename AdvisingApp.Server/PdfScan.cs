using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

public class PdfScan
{
    public static void ScanPdf()
    {
        using (PdfDocument document = PdfDocument.Open(@".\uploaded-images\Lorem Ipsum.pdf"))
        {
            foreach (Page page in document.GetPages())
            {
                IReadOnlyList<Letter> letters = page.Letters;
                string example = string.Join(string.Empty, letters.Select(x => x.Value));

                IEnumerable<Word> words = page.GetWords();
                Console.WriteLine(words);
            }
        }
    }
}