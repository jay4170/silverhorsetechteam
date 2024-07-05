using Microsoft.AspNetCore.Mvc;
using silverhorse.Business_Logic;
using silverhorse.Dtos;
using System.Threading.Tasks;

namespace silverhorse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly Posts _postFactory;

        public PostsController(Posts postFactory)
        {
            _postFactory = postFactory;
        }

        /// <summary>
        /// Get a post by its ID.
        /// </summary>
        /// <param name="postId">The ID of the post to retrieve.</param>
        /// <returns>The requested post.</returns>
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetAsync(int postId)
        {
            var post = await _postFactory.GetAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
