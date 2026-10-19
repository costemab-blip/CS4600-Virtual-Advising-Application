using AdvisingApp.Server;
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
                //Console.WriteLine($" ({word.Text}) (PointSize: {GetPointSize(word)}) (TextType: {GetTextType(word)})");
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
        if (GetPointSize(inputWord) > 8)
        {
            return "Section Header";
        }
        else
        {
            return "Body Text";
        }
    }
    //This section is incomplete, I still need to build the functionality
    public static void GetSections(PdfDocument inputDoc)
    {
        List<SectionDataItem> sectionDataItems = new List<SectionDataItem>();

        foreach (Page page in inputDoc.GetPages())
        {
            foreach (Word word in page.GetWords())
            {
                if (GetTextType(word) == "Header")
                {
                    string sectionTitle = "";
                    while (true)
                    {
                        sectionTitle += word.Text + " ";
                        sectionDataItems.Add(new SectionDataItem { SectionTitle = sectionTitle });
                    }
                }

                while (GetTextType(word) != "Header")
                {
                    string sectionContent = "";
                    sectionContent += word.Text + " ";
                    
                    //Console.WriteLine("Section Content: " + sectionContent);
                }
            }
        }
    }
}

