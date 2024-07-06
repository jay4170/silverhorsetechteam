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
    public class AlbumsController : ControllerBase
    {
        private readonly Albums _albumFactory;

        public AlbumsController(Albums albumFactory)
        {
            _albumFactory = albumFactory;
        }

        /// <summary>
        /// Get a single album by its ID.
        /// </summary>
        /// <param name="albumId">The ID of the album to retrieve.</param>
        /// <returns>The requested album or a 404 Not Found response if the album is not found.</returns>
        [HttpGet("{albumId}")]
        public async Task<IActionResult> GetAlbumAsync(int albumId)
        {
            var album = await _albumFactory.GetAlbumAsync(albumId);
            if (album == null)
            {
                return NotFound("Album not found");
            }
            return Ok(album);
        }

        /// <summary>
        /// Get a list of all albums.
        /// </summary>
        /// <returns>A list of albums or a 404 Not Found response if no albums are found.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAlbumsAsync()
        {
            var albums = await _albumFactory.GetAlbumListAsync();
            if (albums == null || albums.Count == 0)
            {
                return NotFound("No albums found");
            }
            return Ok(albums);
        }

        /// <summary>
        /// Create a new album.
        /// </summary>
        /// <param name="album">The new album to create.</param>
        /// <returns>A 201 Created response with the created album.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAlbumAsync(BaseAlbumDto album)
        {
            var response = await _albumFactory.CreateAlbumAsync(album);

            return Ok(response);
        }

        /// <summary>
        /// Update an existing album.
        /// </summary>
        /// <param name="album">The album information to update.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the outcome of the update operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAlbumAsync(BaseAlbumDto album)
        {
            var response = await _albumFactory.UpdateAlbumAsync(album);

            return Ok(response);

        }

        /// <summary>
        /// Delete an album.
        /// </summary>
        /// <param name="albumId">The ID of the album to delete.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating the outcome of the delete operation.
        /// Returns <see cref="OkResult"/> if the album was deleted successfully.
        /// Returns <see cref="NotFoundResult"/> if the album was not found.
        /// </returns>
        [HttpDelete("{albumId}")]
        public async Task<IActionResult> DeleteAlbumAsync(int albumId)
        {
            var response = await _albumFactory.DeleteAlbumAsync(albumId);
            if (response)
            {
                return Ok("Album deleted successfully");
            }
            else
            {
                return NotFound("Album not found or could not be deleted");
            }
        }
    }
}
