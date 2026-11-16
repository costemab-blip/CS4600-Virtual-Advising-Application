using AdvisingApp.Server;
using System.Linq;
public class InputReader
{
    public static List<UNICourseItem> GetRemainingCourses(List<UNICourseItem> completedCourses, List<UNICourseItem> requiredCourses)
    {
        List<UNICourseItem> remainingCourses = new List<UNICourseItem>();
        foreach (var courseItem in requiredCourses) {
            if(courseItem.CourseCode != null && !completedCourses.Any(c => c.CourseCode == courseItem.CourseCode && c.CourseTopic == courseItem.CourseTopic))
            {
                remainingCourses.Add(courseItem);
                Console.WriteLine($"Added course:  {courseItem.CourseTopic} {courseItem.CourseCode} {courseItem.Title}");
            }
        }
        return remainingCourses;
    }

    public static List<UNICourseItem> GetCourses(string filePath)
    {
        List<UNICourseItem> courses = new List<UNICourseItem>();
        var fileContent = File.ReadLines(filePath);
        foreach (var line in fileContent)
        {
            List<string> tempList = GetListFromLine(line);
            UNICourseItem Course = MapListToUNICourseItem(tempList);
            courses.Add(Course);
        }
        return courses;
    }

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
            Units = wordList[wordList.Count - 1],
            Term = wordList[wordList.Count - 2],
            Grade = wordList[wordList.Count - 3],
        };

        return courseItem;
    }

    public static List<string> GetListFromLine(string line)
    {
        List<string> outputList = new List<string>();
        string[] words = line.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            outputList.Add(word);
        }
        return outputList;
    }

    public static List<UNICourseItem> TrimList(List<UNICourseItem> course_list, List<UNICourseItem> completedCourses )
    {
        foreach( UNICourseItem course in course_list ){
            if (course.CourseCode == null || course.CourseTopic == null || course.Title == null || course.Units == null || course.Term == null || course.Grade == null)
            {
                course_list.Remove(course);
            }
            
            if (course.CourseCode == "Course" || course.CourseTopic == "Topic" || course.Title == "Title" || course.Units == "Units" || course.Term == "Term" || course.Grade == "Grade")
            {
                course_list.Remove(course);
            }

            if (completedCourses.Any(c => c.CourseCode == course.CourseCode && c.CourseTopic == course.CourseTopic))
            {
                course_list.Remove(course);
            }

        }
        return course_list;
    }
}