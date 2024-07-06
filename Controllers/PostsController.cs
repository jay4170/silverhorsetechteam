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

    public class PostsController : ControllerBase
    {
        private readonly Posts _postFactory;

        public PostsController(Posts postFactory)
        {   
            _postFactory = postFactory;
        }

        /// <summary>
        /// Get a single post by its ID.
        /// </summary>
        /// <param name="postId">The ID of the post to retrieve.</param>
        /// <returns>The requested post or a 404 Not Found response if the post is not found.</returns>
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostAsync(int postId)
        {
            var post = await _postFactory.GetPostAsync(postId);
            if (post == null)
            {
                return NotFound("Post not found");
            }
            return Ok(post);
        }

        /// <summary>
        /// Get a list of all posts.
        /// </summary>
        /// <returns>A list of posts or a 404 Not Found response if no posts are found.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var posts = await _postFactory.GetPostListAsync();
            if (posts == null || posts.Count == 0)
            {
                return NotFound("No posts found");
            }
            return Ok(posts);
        }

        /// <summary>
        /// Create a new post.
        /// </summary>
        /// <param name="post">The new post to create.</param>
        /// <returns>A 201 Created response with the created post.</returns>
        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(BasePostDto post)
        {
            var response = await _postFactory.CreatePostAsync(post);

            return Ok(response);
        }

        /// <summary>
        /// Create a new post.
        /// </summary>
        /// <param name="post">The new post to create.</param>
        /// <returns>A 201 Created response with the created post.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePostAsync(BasePostDto post)
        {
            var response = await _postFactory.UpdatePostAsync(post);

            return Ok(response);
        }


        /// <summary>
        /// Delete a post.
        /// </summary>
        /// <param name="postId">The ID of the post to delete.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating the outcome of the delete operation.
        /// Returns <see cref="OkResult"/> if the post was deleted successfully.
        /// Returns <see cref="NotFoundResult"/> if the post was not found.
        /// </returns>
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePostAsync(int postId)
        {
            var response = await _postFactory.DeletePostAsync(postId);
            if (response)
            {
                return Ok("Post deleted successfully");
            }
            else
            {
                return NotFound("Post not found or could not be deleted");
            }
        }

    }
}
