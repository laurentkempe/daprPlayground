using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcStreamService;
using static System.Console;

namespace GrpcStreamClient
{
    class Program
    {
        static async Task Main()
        {
            WriteLine("Hello Dapr gRPC streaming proxying!");

            var channel = GrpcChannel.ForAddress("http://localhost:50001");
            var greeterClient = new Greeter.GreeterClient(channel);

            var metadata = new Metadata
            {
                { "dapr-app-id", "grpcservice" }
            };
            var helloRequest = new HelloRequest { Name = "Laurent" };

            var helloReplies = greeterClient.SayHello(helloRequest, metadata);
            
            await foreach (var helloReply in helloReplies.ResponseStream.ReadAllAsync())
            {
                WriteLine($"Reply: {helloReply.Message}");
            }
        }
    }
}
