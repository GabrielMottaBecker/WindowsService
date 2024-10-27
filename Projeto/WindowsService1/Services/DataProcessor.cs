using System.Threading.Tasks;
using WindowsService1.Data;
using WindowsService1.Services;

namespace WindowsService1.Services
{
    public class DataProcessor
    {
        private readonly NewsApiService _newsService;
        private readonly WeatherApiService _weatherService;

        public DataProcessor()
        {
            _newsService = new NewsApiService();
            _weatherService = new WeatherApiService();
        }

        public async Task Execute()
        {
            // Coletar notícias do IBGE
            var news = await _newsService.GetNewsAsync();
            LoggingService.Log("Notícias coletadas.");

            // Coletar clima atual
            var weather = await _weatherService.GetWeatherAsync("Palotina");
            LoggingService.Log("Clima coletado.");

            // Processar dados (exemplo: fazer alguma transformação ou filtro)
            // Aqui você pode adicionar lógica de transformação conforme necessário

            // Salvar dados no repositório
            NewsRepository.SaveNews(news);
            WeatherRepository.SaveWeather(weather);
        }
    }
}