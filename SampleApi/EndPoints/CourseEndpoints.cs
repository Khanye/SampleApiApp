using SampleApi.Data;

namespace SampleApi.EndPoints
{
    public static class CourseEndpoints
    {
        public static void AddCourseEndpoints(this WebApplication app)
        {
            app.MapGet("/courses", LoadAllCoursesAsync);
             app.MapGet("/courses/{id}", LoadCourseByIdAsync);
        }
        private static async Task<IResult> LoadAllCoursesAsync(
            CourseData data,
            string? courseType,
            string? search,
            int? delay)
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

            if(delay is not null)
            {
                //Max delay of 5 minutes (300 000 milliseconds)
                if(delay > 300000)
                {
                    delay = 300000;
                }

                await Task.Delay((int)delay);
            }

            return Results.Ok(output);
        }

        private static async Task<IResult> LoadCourseByIdAsync(CourseData data, int id,int? delay)
        {
            var output = data.Courses.SingleOrDefault(c => c.Id == id);

            if (delay is not null)
            {
                //Max delay of 5 minutes (300 000 milliseconds)
                if (delay > 300000)
                {
                    delay = 300000;
                }

                await Task.Delay((int)delay);
            }

            if (output is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(output);
        }
        

    }
}
    