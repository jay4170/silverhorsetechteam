using silverhorse.Dtos;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace silverhorse.Business_Logic
{
    public class Users
    {
        private readonly HttpClient _httpClient;

        public Users(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get single user by ID
        internal async Task<UserDto> GetUserAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            return null;
        }

        // Get list of users
        internal async Task<List<UserDto>> GetUserListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UserDto>>();
            }
            return new List<UserDto>();
        }

        // Create a new user
        internal async Task<UserDto> CreateUserAsync(UserDto user)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("users", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            throw new Exception($"Failed to create user: {response.ReasonPhrase}");
        }

        // Update an existing user
        internal async Task<UserDto> UpdateUserAsync(UserDto user)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"users/{user.Id}", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            return null;
        }

        // Delete a user by ID
        internal async Task<bool> DeleteUserAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
