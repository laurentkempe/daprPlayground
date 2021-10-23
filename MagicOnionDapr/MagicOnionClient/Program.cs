using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using MagicOnionShared;
using static System.Console;

namespace MagicOnionClient
{
    internal class Program
    {
        private static async Task Main()
        {
            WriteLine("Hello Dapr gRPC proxying leveraging MagicOnion!");

            var channel = GrpcChannel.ForAddress("http://localhost:50001");
            var metadata = new Metadata { { "dapr-app-id", "MagicOnionServer" } };

            // Create a proxy to call the server transparently.
            var client = MagicOnion.Client.MagicOnionClient.Create<IMyFirstService>(channel).WithHeaders(metadata);
            
            // Call the server-side method using the proxy.
            var result = await client.SumAsync(123, 456);

            WriteLine($"Result: {result}");
        }
    }
}