using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherForecastProxyService
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count);
    }

    public class WeatherForecastClient : IWeatherForecastClient
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count)
        {
            var weatherForecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast");

            return weatherForecasts.Take(count);
        }
    }
}