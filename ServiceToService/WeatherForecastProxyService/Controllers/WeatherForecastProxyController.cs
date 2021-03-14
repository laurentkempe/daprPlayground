using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastProxyService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastProxyController : ControllerBase
    {
        private readonly IWeatherForecastClient _weatherForecastClient;

        public WeatherForecastProxyController(IWeatherForecastClient weatherForecastClient)
        {
            _weatherForecastClient = weatherForecastClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(int count)
        {
            return await _weatherForecastClient.GetWeatherForecast(count);
        }
    }
}
