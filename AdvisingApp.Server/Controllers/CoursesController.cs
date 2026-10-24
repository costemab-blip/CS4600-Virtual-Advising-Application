using Microsoft.AspNetCore.Mvc;
namespace AdvisingApp.Server.Controllers;

[ApiController]
[Route("api/courses")]

public class CoursesController : ControllerBase
{
    private readonly IWebHostEnvironment environment;

    public CoursesController(IWebHostEnvironment environment)
    {
        this.environment = environment;
    }

    [HttpGet("remaining")]
    public ActionResult<List<UNICourseItem>> GetRemainingCourses()
    {
        string completedCoursePath = Path.Combine(
            environment.ContentRootPath,
            "uploaded-images",
            "advisement-report-no-headings.txt");

        string requiredCoursesPath = Path.Combine(
            environment.ContentRootPath,
            "uploaded-images",
            "required-classes.txt");

        List<UNICourseItem> completedCourses =
            InputReader.GetCompletedCourses(completedCoursePath);

        List<UNICourseItem> requiredCourses =
           InputReader.GetRequiredCourses(requiredCoursesPath);

        List<UNICourseItem> remainingCourses =
            InputReader.GetRemainingCourses(completedCourses, requiredCourses);

        return Ok(remainingCourses);
    }
}

