using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Worker.Controllers
{
    [Route("scheduleHttpJob")]
    [ApiController]
    public class ScheduledHttpJobController : ControllerBase
    {
        private readonly ILogger<ScheduledHttpJobController> _logger;

        public ScheduledHttpJobController(ILogger<ScheduledHttpJobController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void HttpJob()
        {
            _logger.LogInformation($"{nameof(ScheduledHttpJobController)} called 😎");
        }
    }
}
