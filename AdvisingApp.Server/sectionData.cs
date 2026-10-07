namespace AdvisingApp.Server
{
    public class SectionDataItem
    {
        public string? SectionTitle { get; set; }
        public string? SectionDescription { get; set; }
        public string? SectionContent { get; set; }
        public List<UNICourseItem>? SectionCourses { get; set; }
    }
}
