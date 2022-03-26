using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InMemoryCaching.Data.Models;

namespace InMemoryCaching.Data.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        Task<List<User>> GetUsersAsync();
        Task<List<User>> GetUsersCacheAsync();
    }
}
