namespace SampleApi.EndPoints
{
    public static class RootEndpoints
    {
        public static void AddRootEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World!");
        }
    }
}
