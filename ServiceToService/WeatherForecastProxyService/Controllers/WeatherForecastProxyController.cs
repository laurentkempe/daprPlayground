using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherForecastProxyService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastProxyController : ControllerBase
    {
        private readonly ILogger<WeatherForecastProxyController> _logger;
        private readonly IWeatherForecastClient _weatherForecastClient;

        public WeatherForecastProxyController(ILogger<WeatherForecastProxyController> logger, IWeatherForecastClient weatherForecastClient)
        {
            _logger = logger;
            _weatherForecastClient = weatherForecastClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(int count)
        {
            return await _weatherForecastClient.GetWeatherForecast(count);
        }
    }
}
