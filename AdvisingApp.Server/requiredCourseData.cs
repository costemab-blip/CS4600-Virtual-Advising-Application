namespace AdvisingApp.Server
{
    public class requiredCourseData
    {
        public List<UNICourseItem> CSCoreCoursesList = InputReader.GetCourses("required-cs-courses.txt");
        public List<UNICourseItem> foundationsCourseList = InputReader.GetCourses("required-foundations-courses.txt");
        public List<UNICourseItem> mathCoreCoursesList = InputReader.GetCourses("required-math-courses.txt");
        public List<UNICourseItem> softwareEngineeringCoursesList = InputReader.GetCourses("software-engineering-courses.txt");
        public List<UNICourseItem> systemsCourseList = InputReader.GetCourses("systems-courses.txt");
        public List<UNICourseItem> CourseHistoryList = InputReader.GetCompletedCourses("completed-classes.txt");
    }
}
