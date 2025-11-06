using DemoApp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        WeatherForecast weatherForecast = new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureCelsius = 32,
            Summary = "Hot and dry summer weather"
        };

        string weatherForecastJsonViaText = System.Text.Json.JsonSerializer.Serialize(weatherForecast);

        string weatherForecastJsonViaNewton = JsonConvert.SerializeObject(weatherForecast);

        Console.WriteLine(weatherForecastJsonViaText);
        Console.WriteLine(weatherForecastJsonViaNewton);

        string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../../../JsonForecast.json");

        var weatherForecastObjectUsingTextJson = System.Text.Json.JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);
        var weatherForecastObjectUsingNewtonJson = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonString);

        foreach (var item in weatherForecastObjectUsingTextJson)
        {
            Console.WriteLine($"The weather on {item.Date} was {item.Summary} and the temperature was {item.TemperatureCelsius}");
        }

        foreach (var item in weatherForecastObjectUsingNewtonJson)
        {
            Console.WriteLine($"The weather on {item.Date} was {item.Summary} and the temperature was {item.TemperatureCelsius}");
        }
    }
}