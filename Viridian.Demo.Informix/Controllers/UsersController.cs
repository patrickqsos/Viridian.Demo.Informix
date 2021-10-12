using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Viridian.Demo.Informix.DataAccess;
using Viridian.Demo.Informix.Repositories.Interfaces;

namespace Viridian.Demo.Informix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersRepository _usersRepository;
        
        public UsersController(ILogger<UsersController> logger, IUsersRepository usersRepository)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Find all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            _logger.LogInformation("Finding all users");
            return _usersRepository.FindAll();
        }
        
        /// <summary>
        /// Find users by status
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("find")]
        public IEnumerable<Users> GetByStatus(string status)
        {
            _logger.LogInformation("Finding users by status: {status}", status);
            return _usersRepository.FindByStatus(status);
        }
        
        /// <summary>
        /// Insert new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>User inserted</returns>
        [HttpPost]
        public Users Insert([FromBody] Users user)
        {
            _logger.LogInformation("Inserting new user");
            return _usersRepository.Insert(user);
        }
        
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>User updated</returns>
        [HttpPut]
        public Users Update([FromBody] Users user)
        {
            _logger.LogInformation("Updating new user");
            return _usersRepository.Update(user);
        }
    }
}