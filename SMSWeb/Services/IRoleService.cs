using Microsoft.AspNetCore.Mvc;
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;

namespace SMSWeb.Services
{
    public interface IRoleService
    {
        
         Task<ServiceRespone> CreateRole(Role role);
         Task<ServiceRespone> UpdateRole(Role role);

         Task<ServiceRespone> DeleteRole(int id);

         Task<List<Role>> GetRoles();
         Task<Role> GetRoleById(int id);
    }
}
