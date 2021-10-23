using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcStreamService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            foreach (var x in Enumerable.Range(1, 10))
            {
                await responseStream.WriteAsync(new HelloReply
                {
                    Message = $"Hello {request.Name} {x}"
                });

                await Task.Delay(200);
            }
        }
    }
}
