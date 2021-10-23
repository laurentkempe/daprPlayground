using MagicOnion;

namespace MagicOnionShared
{
    // Defines .NET interface as a Server/Client IDL.
    // The interface is shared between server and client.
    public interface IMyFirstService : IService<IMyFirstService>
    {
        // The return type must be `UnaryResult<T>`.
        UnaryResult<int> SumAsync(int x, int y);
    }
}