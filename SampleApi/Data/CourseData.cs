using SampleApi.Models;
using System.Text.Json;

namespace SampleApi.Data
{
    public class CourseData
    {
        public List<CourseModel> Courses { get; private set; }

        public CourseData()
        {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(), 
                "Data",
                "coursedata.json"
                );

            string jsonData = File.ReadAllText(filePath);

            Courses = JsonSerializer.Deserialize<List<CourseModel>>(jsonData, options) 
                ?? new List<CourseModel>();//or just new()
        }
    }
}
