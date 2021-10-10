using System.Text.Json;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Worker.Controllers
{
    [Route("scheduleHttpJob")]
    [ApiController]
    public class ScheduledHttpJobController : ControllerBase
    {
        private readonly ILogger<ScheduledHttpJobController> _logger;
        private readonly DaprClient _daprClient;

        public ScheduledHttpJobController(ILogger<ScheduledHttpJobController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpPost]
        public async Task HttpJob()
        {
            _logger.LogInformation($"{nameof(ScheduledHttpJobController)} called 😎");

            var response = await _daprClient.InvokeBindingAsync(new BindingRequest("httpJob", "get"));
            var timeData = JsonSerializer.Deserialize<TimeData>(response.Data.Span);

            _logger.LogInformation($"⏰ in Paris {timeData?.utc_datetime}");
        }
    }
}
