using Newtonsoft.Json.Linq;

namespace OpenWeatherMap;

class Program
{
    static async Task Main(string[] args)
    {
        //Console.WriteLine("What city?");
        //var city = Console.ReadLine();

        //var client = new HttpClient();
        //var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=2db964457f1ccd083a957e7e92aa5681&units=imperial";
        //var response = client.GetStringAsync(weatherURL).Result;
        //var weatherObject = JObject.Parse(response);
        //Console.WriteLine(weatherObject["main"]["temp"]);
        //Console.WriteLine($"{city} tempeture: {weatherObject["main"]["temp"]}°F");

        Console.WriteLine("What city?");
        var city = Console.ReadLine();

        var client = new HttpClient();
        var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=2db964457f1ccd083a957e7e92aa5681&units=imperial";

        try
        {
            var response = await client.GetStringAsync(weatherURL);
            var weatherObject = JObject.Parse(response);
            Console.WriteLine();
            Console.WriteLine($"{city} tempeture: {weatherObject["main"]["temp"]}°F");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}

