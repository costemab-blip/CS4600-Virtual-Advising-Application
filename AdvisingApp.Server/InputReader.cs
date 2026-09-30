using AdvisingApp.Server;
public class InputReader
{
    public static List<UNICourseItem> GetCompletedCourses(string filePath)
    {
        List<UNICourseItem> completedCourses = new List<UNICourseItem>();
        var fileContent = File.ReadLines(filePath);

        foreach (var line in fileContent)
        {
            List<string> tempList = GetListFromLine(line);
            UNICourseItem Course = MapListToUNICourseItem(tempList);

            if (Course.Grade == "W" || Course.Grade == "F" || Course.Grade == "D" || Course.Grade == "D+" || Course.Grade == "D-")
            {
                continue;
            }
            completedCourses.Add(Course);
        }
        return completedCourses;
    }

    public static UNICourseItem MapListToUNICourseItem(List<string> wordList)
    {
        string title = "";
        for (int index = 2; index < wordList.Count;)
        {
            while (double.TryParse(wordList[index], out _) == false)
            {
                if (wordList[index] == "RPL")
                {
                    break;
                }
                title += wordList[index] + " ";
                index += 1;
            }
            break;
        }
        UNICourseItem courseItem = new UNICourseItem()
        {
            CourseTopic = wordList[0],
            CourseCode = wordList[1],
            Title = title,
            Units = wordList[wordList.Count - 5],
            Year = wordList[wordList.Count - 4],
            Term = wordList[wordList.Count - 3],
            Grade = wordList[wordList.Count - 2],
            Type = wordList[wordList.Count - 1],
        };
        return courseItem;
    }

    public static List<string> GetListFromLine(string line)
    {
        List<string> outputList = new List<string>();
        string[] words = line.Split([' ', '\n', '\r'],
        StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            outputList.Add(word);
        }
        return outputList;
    }
}