using Dapr.Proto.Components.V1;
using Grpc.Core;

namespace FileSystemStateStorePluggableComponent.Services;

public sealed class FileSystemStateService : StateStore.StateStoreBase
{
    private readonly ILogger<FileSystemStateService> _logger;

    public FileSystemStateService(ILogger<FileSystemStateService> logger)
    {
        _logger = logger;
    }
    
    public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Get method called");

        return Task.FromResult(new GetResponse());
    }
}