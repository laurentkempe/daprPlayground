using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace WeatherForecastProxyService
{
    public interface IWeatherForecastClient
    {
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count);
    }
}