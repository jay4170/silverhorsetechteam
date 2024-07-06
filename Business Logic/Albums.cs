using silverhorse.Dtos;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace silverhorse.Business_Logic
{
    public class Albums
    {
        private readonly HttpClient _httpClient;

        public Albums(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get single album by ID
        internal async Task<BaseAlbumDto> GetAlbumAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Albums/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseAlbumDto>();
            }
            return null;
        }

        // Get list of Albums
        internal async Task<List<BaseAlbumDto>> GetAlbumListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Albums");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<BaseAlbumDto>>();
            }
            return new List<BaseAlbumDto>();
        }

        // Create a new album
        internal async Task<BaseAlbumDto> CreateAlbumAsync(BaseAlbumDto album)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(album),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("Albums", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseAlbumDto>();
            }
            throw new Exception($"Failed to create album: {response.ReasonPhrase}");
        }

        // Update an existing album
        internal async Task<BaseAlbumDto> UpdateAlbumAsync(BaseAlbumDto album)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(album),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"Albums/{album.Id}", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseAlbumDto>();
            }
            return null;
        }

        // Delete a album by ID
        internal async Task<bool> DeleteAlbumAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"Albums/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
