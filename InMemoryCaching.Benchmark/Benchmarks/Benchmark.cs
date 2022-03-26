using InMemoryCaching.Data.Data;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Benchmark.Benchmarks
{
    public class Benchmark
    {
        protected readonly UserRepository Repository;
        public Benchmark()
        {
            IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
            Repository = new UserRepository(cache);
        }
    }
}
