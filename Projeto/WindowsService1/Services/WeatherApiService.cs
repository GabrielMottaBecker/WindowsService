using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WindowsService1.Services;

namespace WindowsService1.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService()
        {
            _httpClient = ApiClientFactory.CreateClient("https://api.open-meteo.com/v1/");
        }

        public async Task<JObject> GetWeatherAsync(string location)
        {
            var response = await _httpClient.GetAsync($"forecast?latitude=-10.0&longitude=-55.0&current_weather=true");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }
    }
}