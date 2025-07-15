using SampleApi.Data;

namespace SampleApi.EndPoints
{
    public static class CourseEndpoints
    {
        public static void AddCourseEndpoints(this WebApplication app)
        {
            app.MapGet("/courses", LoadAllCourses);
             app.MapGet("/courses/{id}", LoadCourseById);
        }
        private static IResult LoadAllCourses(
            CourseData data,
            string? courseType,
            string? search)
        {
            var output = data.Courses;

            if(string.IsNullOrWhiteSpace(courseType) == false)
            {
                output.RemoveAll(c => string.Compare
                (c.CourseType,courseType,
                StringComparison.OrdinalIgnoreCase) != 0);// If the strings are the same it returns 0,ut if not it returns a non-zero value
            }

            if(string.IsNullOrWhiteSpace(search) is false)
            {
                //Remove all couses that do not contain the search term
                output.RemoveAll(c => !c.CourseName.Contains(search,StringComparison.OrdinalIgnoreCase) &&
                 !c.ShortDescription.Contains(search,StringComparison.OrdinalIgnoreCase));
            }

            return Results.Ok(output);
        }

        private static IResult LoadCourseById(CourseData data, int id)
        {
            var output = data.Courses.SingleOrDefault(c => c.Id == id);
            if(output is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(output);
        }
        

    }
}
    