using BenchmarkDotNet.Attributes;
using InMemoryCaching.Data.Models;

namespace InMemoryCaching.Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    public class CachingBenchmarks : Benchmark
    {
        [Benchmark]
        public List<User> WithoutCachingNoAsync()
        {
            return Repository.GetUsers();
        }

        [Benchmark]
        public async Task<List<User>> WithoutCachingWithAsync()
        {
            return await Repository.GetUsersAsync();
        }

        [Benchmark]
        public async Task<List<User>> WithCachingWithAsync()
        {
            return await Repository.GetUsersCacheAsync();
        }
    }
}
