using AdvisingApp.Server;
using System.Linq;
using UglyToad.PdfPig.Content;
public class InputReader
{
    public static List<string> getWords(string filePath)
    {
        List<string> wordList = new List<string>();
        var linesRead = File.ReadLines(filePath);

        foreach (var line in linesRead)
        {
            string[] words = line.Split([' ', '\n', '\r'],
            StringSplitOptions.RemoveEmptyEntries);
            List<string> tempList = new List<string>();
            foreach (var word in words)
            {
                tempList.Add(word);
            }

            string title = "";
            for (int Index = 2; Index < tempList.Count; Index++)
            {
                while (double.TryParse(tempList[Index], out _) == false)
                {
                    title += tempList[Index] + " ";
                }
                break;
            }
            UNICourseItem Course = new UNICourseItem()
            {
                CourseTopic = tempList[0],
                CourseCode = tempList[1],
                Title = title,
                Units = tempList[tempList.Count - 5],
                Term = tempList[tempList.Count - 3],
                Year = tempList[tempList.Count - 4],
                Grade = tempList[tempList.Count - 2],
                Type = tempList[tempList.Count - 1],
            };
        }
        return wordList;
    }
}

