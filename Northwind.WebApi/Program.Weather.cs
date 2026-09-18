public partial class Program
{
	private static readonly string[] summaries = [ "Freezing", "Bracing",
	"Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" ];
	internal static WeatherForecast[] GetWeather(int days = 5)
	{
		WeatherForecast[] forecast = [.. Enumerable.Range(1, days)
		.Select(index => new WeatherForecast
		(
		DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
		Random.Shared.Next(-20, 55),
		summaries[Random.Shared.Next(summaries.Length)]
		))];
		return forecast;
	}
	internal readonly record struct WeatherForecast(DateOnly Date,
	int TemperatureC, string? Summary)
	{
		public int TemperatureF => 32 +
		(int)(TemperatureC / 0.5556);
	}
}