using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Client;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubGraphQLService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly DaprClient _daprClient;

        // Dapr - Inject DaprClient from .NET SDK Client using IoC 
        public GitHubController(ILogger<GitHubController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<Viewer> GetUser()
        {
            var metadata = new Dictionary<string, string>
            {
                {
                    "query", @"query { 
                                viewer { 
                                    name
                                    avatarUrl
                                }
                            }"
                }
            };

            // Dapr - Use Dapr .NET SDK Client to invoke the GraphQ binding component of the Dapr Binding building block 
            var root = await _daprClient.InvokeBindingAsync<Empty, Root>("github-graphql-binding", "query", new Empty(), metadata);

            _logger.LogInformation("User: {Name} - {AvatarUrl}", root.Viewer.Name, root.Viewer.AvatarUrl);
            
            return root.Viewer;
        }
    }
    
    public class Viewer
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }
    }

    public class Root
    {
        public Viewer Viewer { get; set; }
    }
}
