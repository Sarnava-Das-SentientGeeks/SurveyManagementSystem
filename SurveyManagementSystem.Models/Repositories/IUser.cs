using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;

namespace SurveyManagementSystem.DAL.Repositories
{
    public interface IUser
    {
        public Task<ServiceRespone> CreateAsync(User user, IList<int> roleIds);
        public Task<ServiceRespone> UpdateAsync(User user, IList<int> roleIds);
        public Task<ServiceRespone> DeleteAsync(int id);

        public Task<List<User>> GetAsync();

        public Task<User> GetByIdAsync(int id);

        public Task<Dictionary<int, List<RoleDTO>>> GetUserRolesAsync();
        public Task<List<RoleDTO>> GetRolesByIdAsync(int id);
    }
}
