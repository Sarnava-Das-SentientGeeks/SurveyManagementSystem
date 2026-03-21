
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;

namespace SMSWeb.Services
{
        public class UserService : IUserService
        {
                private readonly HttpClient _httpClient;
                private readonly string route="api/users";

                public UserService(HttpClient httpClient)
                {
                    this._httpClient = httpClient;
                }
                public async Task<ServiceRespone> CreateAsync(UserDTO user)
                {
                    var data = await _httpClient.PostAsJsonAsync(route, user);
                    var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
                    return response;       
                }
                public async Task<ServiceRespone> UpdateAsync(UserDTO user)
                {
                    var data = await _httpClient.PutAsJsonAsync(route, user);
                    var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
                    return response;

                }

                public async Task<ServiceRespone> DeleteAsync(int id)
                {
                    var data = await _httpClient.DeleteAsync(route + $"/{ id}");
                    var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
                    return response;
                }

                public async Task<List<User>> GetAsync() => await _httpClient.GetFromJsonAsync<List<User>>(route);

          

                public async Task<User> GetByIdAsync(int id)
                {
                            var data = await _httpClient.GetFromJsonAsync<User>(route + $"/{id}");
                            return data;
                }

                public async Task<Dictionary<int, List<RoleDTO>>> GetUserRolesAsync()
                {
                        
                        var data = await _httpClient.GetFromJsonAsync<Dictionary<int, List<RoleDTO>>>(route+"/roles");
                        return data;
                }

                public async Task<List<RoleDTO>> GetRolesByIdAsync(int id)
                {
                        var data = await _httpClient.GetFromJsonAsync<List<RoleDTO>>(route + $"/roles/{id}");
                        return data;
                }




    }
}

