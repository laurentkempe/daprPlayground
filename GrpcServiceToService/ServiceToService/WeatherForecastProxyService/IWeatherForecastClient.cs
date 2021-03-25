using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherForecastProxyService
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count);
    }
}