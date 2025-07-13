namespace SampleApi.Startup
{
    public static class DependanciesConfig
    {
        public static void AddDependancies(this WebApplicationBuilder builder)
        {
            // Add any dependencies here
            // For example, if you have a database context or a service, you can add it like this:
            // services.AddDbContext<MyDbContext>(options => options.UseSqlServer("YourConnectionString"));
            // services.AddScoped<IMyService, MyService>();

            builder.Services.AddOpenApiServices();
        }
        
        public static void UseDependancies(this WebApplication app)
        {
            // Configure any middleware or services that need to be used in the application pipeline
            // For example, if you have a custom middleware, you can use it like this:
            // app.UseMiddleware<MyCustomMiddleware>();
        }  
    }
}
