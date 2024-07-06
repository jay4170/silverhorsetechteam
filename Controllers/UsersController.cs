using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using silverhorse.Business_Logic;
using silverhorse.Dtos;
using System.Threading.Tasks;

namespace silverhorse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly Users _userFactory;

        public UsersController(Users userFactory)
        {
            _userFactory = userFactory;
        }

        /// <summary>
        /// Get a single user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The requested user or a 404 Not Found response if the user is not found.</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var user = await _userFactory.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        /// <summary>
        /// Get a list of all users.
        /// </summary>
        /// <returns>A list of users or a 404 Not Found response if no users are found.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userFactory.GetUserListAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found");
            }
            return Ok(users);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user">The new user to create.</param>
        /// <returns>A 201 Created response with the created user.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto user)
        {
            var response = await _userFactory.CreateUserAsync(user);

            return Ok(response);
        }

        /// <summary>
        /// Update an existing user.
        /// </summary>
        /// <param name="user">The user information to update.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the outcome of the update operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserDto user)
        {
            var response = await _userFactory.UpdateUserAsync(user);

            return Ok(response);
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating the outcome of the delete operation.
        /// Returns <see cref="OkResult"/> if the user was deleted successfully.
        /// Returns <see cref="NotFoundResult"/> if the user was not found.
        /// </returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var response = await _userFactory.DeleteUserAsync(userId);
            if (response)
            {
                return Ok("User deleted successfully");
            }
            else
            {
                return NotFound("User not found or could not be deleted");
            }
        }
    }
}
