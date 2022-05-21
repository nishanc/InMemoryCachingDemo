using InMemoryCaching.Data.Models;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Data.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IMemoryCache _memoryCache;

        public UserRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<User> GetUsers()
        {
            List<User> output = new()
            {
                new() { FirstName = "Tim", LastName = "Corey" },
                new() { FirstName = "Sue", LastName = "Storm" },
                new() { FirstName = "Jane", LastName = "Jones" }
            };

            Thread.Sleep(3000);

            return output;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> output = new()
            {
                new() { FirstName = "Tim", LastName = "Corey" },
                new() { FirstName = "Sue", LastName = "Storm" },
                new() { FirstName = "Jane", LastName = "Jones" }
            };

            await Task.Delay(3000);

            return output;
        }

        public async Task<List<User>> GetUsersCacheAsync()
        {
            var output = _memoryCache.Get<List<User>>("users");

            if (output is not null) return output;

            #region TryGetValue
            //List<User> users = null;

            //// If found in cache, return cached data
            //if (_memoryCache.TryGetValue("users", out users))
            //{
            //    return users;
            //}
            #endregion

            output = new()
            {
                new() { FirstName = "Tim", LastName = "Corey" },
                new() { FirstName = "Sue", LastName = "Storm" },
                new() { FirstName = "Jane", LastName = "Jones" }
            };

            await Task.Delay(3000);

            #region MemoryCacheEntryOptions
            // Set cache options
            // var cacheOptions = new MemoryCacheEntryOptions()
            //     .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            // _memoryCache.Set("users", output, cacheOptions);
            #endregion

            _memoryCache.Set("users", output, TimeSpan.FromMinutes(1));

            return output;
        }
    }
}
