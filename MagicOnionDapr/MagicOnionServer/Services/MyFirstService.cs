using System;
using MagicOnion;
using MagicOnion.Server;
using MagicOnionShared;

namespace MagicOnionServer
{
    // Implements RPC service in the server project.
    // The implementation class must inherit `ServiceBase<IMyFirstService>` and `IMyFirstService`
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        // `UnaryResult<T>` allows the method to be treated as `async` method.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }
    }
}