using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WindowsService1.Services;

namespace WindowsService1.Services
{
    public class NewsApiService
    {
        private readonly HttpClient _httpClient;

        public NewsApiService()
        {
            _httpClient = ApiClientFactory.CreateClient("https://servicodados.ibge.gov.br/api/v3/");
        }

        public async Task<JArray> GetNewsAsync()
        {
            var response = await _httpClient.GetAsync("noticias");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JArray.Parse(content);
        }
    }
}