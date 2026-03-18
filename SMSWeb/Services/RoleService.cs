
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;


namespace SMSWeb.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpclient;
        private readonly string route = "api/roles";
        public RoleService(HttpClient httpclient) => _httpclient = httpclient;
     
        public async Task<ServiceRespone> CreateRole(Role role)
        {
            var data = await _httpclient.PostAsJsonAsync(route, role);
            //Using generics to deserialize the HTTP response body into your ServiceResponse type.
            //Internally it uses a JSON serializer (usually System.Text.Json) and maps JSON fields to properties of ServiceResponse record
            //var json = await data.Content.ReadAsStringAsync(); var response = JsonSerializer.Deserialize<ServiceResponse>(json); -This is non-generic way
            var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
            return response;
        }
        public async Task<ServiceRespone> UpdateRole(Role role)
        {
            var data = await _httpclient.PutAsJsonAsync(route, role);
            var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
            return response;
        }

        public async Task<ServiceRespone> DeleteRole(int id)
        {
            var data = await _httpclient.DeleteAsync(route + $"/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceRespone>();
            return response;

        }
        public async Task<List<Role>> GetRoles() => await _httpclient.GetFromJsonAsync<List<Role>>(route);

        public async Task<Role> GetRoleById(int id) => await _httpclient.GetFromJsonAsync<Role>(route + $"/{id}");

    }
}
