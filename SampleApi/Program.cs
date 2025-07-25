using SampleApi.EndPoints;
using SampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependancies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();
   
app.MapAllHealthChecks();

app.AddRootEndpoints();
app.AddErrorEndpoints();
app.AddCourseEndpoints();

app.Run();

