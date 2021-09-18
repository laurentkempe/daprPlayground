using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubGraphQLService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private const string GithubGraphQLBinding = "github-graphql-binding";
        private const string GraphQLOperation = "query";
        private readonly ILogger<GitHubController> _logger;
        private readonly DaprClient _daprClient;

        public GitHubController(ILogger<GitHubController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<Viewer> GetUser()
        {
            var metadata = new Dictionary<string, string>()
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

            var root = await _daprClient.InvokeBindingAsync<dynamic, Root>(GithubGraphQLBinding, GraphQLOperation, null, metadata);

            _logger.LogInformation($"User: {root.Viewer.Name} - {root.Viewer.AvatarUrl}");
            
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
