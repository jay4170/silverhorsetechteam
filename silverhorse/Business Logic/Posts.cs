using silverhorse.Dtos;
using System.Net.Http;
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

        // Get single
        internal async Task<BasePostDto> GetAsync(int id)
        {
            BasePostDto post = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadFromJsonAsync<BasePostDto>();
            }
            return post;
        }

        // Additional methods (GetListAsync, Update, Create, Delete) can be implemented similarly
    }
}
