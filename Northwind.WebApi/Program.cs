using Northwind.EntityModels; // To use AddNorthwindContext method.
using Scalar.AspNetCore; // To use MapScalarApiReference method.
using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields.
using Northwind.WebApi.Middleware; // To use custom middleware
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNorthwindContext();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(documentName: "v2");
builder.Services.AddHttpLogging(options =>
{
	options.LoggingFields = HttpLoggingFields.All;
	options.RequestBodyLogLimit = 4096; // Default is 32k.
	options.ResponseBodyLogLimit = 4096; // Default is 32k.
});
const string corsPolicyName = "allowWasmClient";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: corsPolicyName,
	policy =>
	{
		policy.WithOrigins("https://localhost:5152", "http://localhost:5153");
	});
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi(/* "/openapi/{documentName}.yaml" */);
	app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseCors(corsPolicyName);
app.UseMiddleware<SecurityHeaders>();
app.MapGet("/weatherforecast/{days:int?}",
// [EndpointName("This is a name")]//these attributes can be applied to lambdas
// [EndpointSummary("This is a summary.")]//but not method references / delegates
// [EndpointDescription("This is a description.")]
GetWeather).WithName("GetWeatherForecast")/* .WithSummary("").WithDescription("") */;
app.MapCustomers();
app.Run();