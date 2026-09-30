using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

public class PdfScan
{
    public static void ScanPdf()
    {
        using PdfDocument document = PdfDocument.Open(@".\uploaded-images\matthew-costello-advising-report.pdf");

        foreach (Page page in document.GetPages())
        {
            List<string> words = new List<string>();
            page.GetWords().ToList().ForEach(word => words.Add(word.Text));
            foreach (Word word in page.GetWords())
            {
                Console.WriteLine($" ({word.Text}) (PointSize: {GetPointSize(word)}) (TextType: {GetTextType(word)})");
            }
        }
    }

    public static double GetPointSize(Word inputWord)
    {
        double pointSize = 0;
        foreach (var letter in inputWord.Letters)
        {
            pointSize = letter.PointSize;
        }
        return pointSize;
    }

    public static string GetTextType(Word inputWord)
    {
        if (GetPointSize(inputWord) > 9)
        {
            return "Header";
        }
        if(GetPointSize(inputWord) > 8)
        {
            return "Section Header";
        }
        else
        {
            return "Body Text";
        }

    }
}