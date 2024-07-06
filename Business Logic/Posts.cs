using silverhorse.Dtos;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace silverhorse.Business_Logic
{
    public class Posts
    {
        private readonly HttpClient _httpClient;

        public Posts(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get single post by ID
        internal async Task<BasePostDto> GetPostAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BasePostDto>();
            }
            return null;
        }

        // Get list of posts
        internal async Task<List<BasePostDto>> GetPostListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("posts");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<BasePostDto>>();
            }
            return new List<BasePostDto>();
        }

        // Create a new post
        internal async Task<BasePostDto> CreatePostAsync(BasePostDto post)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(post),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("posts", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BasePostDto>();
            }
            throw new Exception($"Failed to create post: {response.ReasonPhrase}");
        }

        // Update an existing post
        internal async Task<BasePostDto> UpdatePostAsync(BasePostDto post)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(post),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"posts/{post.Id}", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BasePostDto>();
            }
            return null;
        }

        // Delete a post by ID
        internal async Task<bool> DeletePostAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"posts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
