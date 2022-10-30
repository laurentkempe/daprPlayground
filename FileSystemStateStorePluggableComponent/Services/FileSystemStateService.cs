using Dapr.Proto.Components.V1;

namespace FileSystemStateStorePluggableComponent.Services;

public sealed class FileSystemStateService : StateStore.StateStoreBase
{
    private readonly ILogger<FileSystemStateService> _logger;

    public FileSystemStateService(ILogger<FileSystemStateService> logger)
    {
        _logger = logger;
    }
}