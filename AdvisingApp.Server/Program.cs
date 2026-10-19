using AdvisingApp.Server;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");
List<UNICourseItem> completedCourses = InputReader.GetCompletedCourses(@"uploaded-images/advisement-report-no-headings.txt");
//Console.WriteLine(string.Join(", ", completedCourses.Select(c => c.Title)));

List<UNICourseItem> requiredCourses = InputReader.GetRequiredCourses(@"uploaded-images/required-classes.txt");
Console.WriteLine("required courses: [ \n " + string.Join(", \n", requiredCourses.Select(c => c.Title)) + " ]");

List<UNICourseItem> remainingCourses = InputReader.GetRemainingCourses(completedCourses, requiredCourses);
Console.WriteLine("remaining courses: [\n " + string.Join(", \n ", remainingCourses.Select(c => c.Title)) + " ]");

app.Run();

