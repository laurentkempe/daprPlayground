using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherForecastProxyService
{
    public class WeatherForecastClient : IWeatherForecastClient
    {
        private readonly HttpClient _backendHttpClient;

        public WeatherForecastClient(HttpClient backendHttpClient)
        {
            _backendHttpClient = backendHttpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count)
        {
            var weatherForecasts =
                await _backendHttpClient.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast");

            return weatherForecasts?.Take(count);
        }
    }
}