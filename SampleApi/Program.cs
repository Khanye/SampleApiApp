using SampleApi.EndPoints;
using SampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependancies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.AddRootEndpoints();
app.AddCourseEndpoints();

app.Run();

