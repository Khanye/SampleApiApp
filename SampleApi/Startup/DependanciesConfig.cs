 using SampleApi.Data;

namespace SampleApi.Startup
{
    public static class DependanciesConfig
    {
        public static void AddDependancies(this WebApplicationBuilder builder)
        {
            // Add any dependencies here
            builder.Services.AddOpenApiServices();
            builder.Services.AddCorsServices();
            builder.Services.AddAllHealthChecks();
            builder.Services.AddTransient<CourseData>();
        }
        
        public static void UseDependancies(this WebApplication app)
        {
            // Configure any middleware or services that need to be used in the application pipeline
            // For example, if you have a custom middleware, you can use it like this:
            // app.UseMiddleware<MyCustomMiddleware>();
        }  
    }
}
