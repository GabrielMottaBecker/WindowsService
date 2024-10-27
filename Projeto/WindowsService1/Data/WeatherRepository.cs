using Newtonsoft.Json.Linq;
using System.IO;

namespace WindowsService1.Data
{
    public static class WeatherRepository
    {
        private const string FilePath = @"C:\Data\weather.json";

        public static void SaveWeather(JObject weather)
        {
            File.WriteAllText(FilePath, weather.ToString());
        }
    }
}