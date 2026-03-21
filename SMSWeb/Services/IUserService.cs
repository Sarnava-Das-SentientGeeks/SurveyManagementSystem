using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;
namespace SMSWeb.Services
{
    public interface IUserService
    {

        public Task<ServiceRespone> CreateAsync(User user);
        public Task<ServiceRespone> UpdateAsync(User user);
        public Task<ServiceRespone> DeleteAsync(int id);

        public Task<List<User>> GetAsync();
             


        public Task<User> GetByIdAsync(int id);

        public Task<Dictionary<int, List<RoleDTO>>> GetUserRolesAsync();


    }
}
