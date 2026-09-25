using AdvisingApp.Server;
public class InputReader
{
    public static List<UNICourseItem> GetCompletedCourses(string filePath)
    {
        List<string> wordList = new List<string>();
        List<UNICourseItem> completedCourses = new List<UNICourseItem>();
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
            for (int Index = 2; Index < tempList.Count;)
            {
                while (double.TryParse(tempList[Index], out _) == false)
                {
                    title += tempList[Index] + " ";
                    Index += 1;
                }
                break;
            }

            UNICourseItem Course = new UNICourseItem()
            {
                CourseTopic = tempList[0],
                CourseCode = tempList[1],
                Title = title,
                Units = tempList[tempList.Count - 5],
                Year = tempList[tempList.Count - 4],
                Term = tempList[tempList.Count - 3],
                Grade = tempList[tempList.Count - 2],
                Type = tempList[tempList.Count - 1],
            };
            completedCourses.Add(Course);
        }
        return completedCourses;
    }
}
