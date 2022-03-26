using InMemoryCaching.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCaching.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _userRepository.GetUsersCacheAsync();
            return Ok(values);
        }
    }
}