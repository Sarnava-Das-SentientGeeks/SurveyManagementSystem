using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;

namespace SurveyManagementSystem.DAL.Repositories
{
    public interface IRole
    {
        public Task<ServiceRespone> CreateRole(Role role);

        public Task<ServiceRespone> DeleteRole(int id);

        public Task<ServiceRespone> UpdateRole(Role role);

        public Task<List<Role>> GetRoles();

        public Task<Role> GetRoleById(int id);
    }
}
