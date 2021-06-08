using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncrementEventController : ControllerBase
    {
        private readonly ILogger<IncrementEventController> _logger;
        
        public IncrementEventController(ILogger<IncrementEventController> logger)
        {
            _logger = logger;
        }
        
        [Topic("pubsub", "CounterIncremented")]
        [HttpPost("increment")]
        public void CounterIncremented([FromBody]int counter)
        {
            _logger.LogInformation($"Counter new value received using CounterIncremented event: {counter}");
        }
    }
}
