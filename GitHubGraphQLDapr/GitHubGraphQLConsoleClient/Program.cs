using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr.Client;
using Google.Protobuf.WellKnownTypes;

namespace GitHubGraphQLConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Dapr!");

            var daprClient = new DaprClientBuilder().UseHttpEndpoint("http://localhost:3500").Build();

            await DaprBinding(daprClient);

            await DaprService(daprClient);
        }

        private static async Task DaprBinding(DaprClient daprClient)
        {
            Console.WriteLine("Using Dapr Binding!");
            
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
            
            // Dapr - Use Dapr .NET SDK Client to invoke the GraphQ binding component of the Dapr Binding building block 
            var root =
                await daprClient.InvokeBindingAsync<Empty, Root>("github-graphql-binding", "query", new Empty(), metadata);

            Console.WriteLine($"User: {root.Viewer.Name} - {root.Viewer.AvatarUrl}");
        }

        private static async Task DaprService(DaprClient daprClient)
        {
            Console.WriteLine("Using Dapr Service Invocation!");

            // Dapr - Use Dapr .NET SDK Client to invoke the Service invocation building block 
            var viewer = await daprClient.InvokeMethodAsync<Viewer>(HttpMethod.Get, "githubgraphqlservice", "GitHub");

            Console.WriteLine($"User: {viewer.Name} - {viewer.AvatarUrl}");
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
