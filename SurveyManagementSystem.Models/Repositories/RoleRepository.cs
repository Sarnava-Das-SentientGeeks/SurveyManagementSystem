using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.DAL.Data;
namespace SurveyManagementSystem.DAL.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly ApplicationDbContext _Dbcontext;
        public RoleRepository(ApplicationDbContext dbcontext) => _Dbcontext = dbcontext;
        public async Task<ServiceRespone> CreateRole(Role role)
        {
            var check = await _Dbcontext.Role.FirstOrDefaultAsync(u => u.Name.ToLower() == role.Name.ToLower());

            if (check != null)
                return new ServiceRespone(false, "Role already exists");
            else
            {
                await _Dbcontext.Role.AddAsync(role);
                _Dbcontext.SaveChanges();
                return new ServiceRespone(true, "Role successfully added");
            }

        }
        public async Task<ServiceRespone> DeleteRole(int id)
        {
            var check = await _Dbcontext.Role.FindAsync(id);
            if (check == null)
                return new ServiceRespone(false, "Role does not exist");
            else
            {
                var role = await _Dbcontext.Role.FindAsync(id);
                _Dbcontext.Role.Remove(role);
                return new ServiceRespone(true, "Role deleted successfully");
            }


        }
        public async Task<ServiceRespone> UpdateRole(Role role)
        {
            if (role != null)
            {
                _Dbcontext.Role.Update(role);
                await _Dbcontext.SaveChangesAsync();
                return new ServiceRespone(true, "Role updated successfully");
            }
            else
                return new ServiceRespone(false, "Role failded to update");
           
        }

        public async Task<Role> GetRoleById(int id) => await _Dbcontext.Role.FindAsync(id);

        public async Task<List<Role>> GetRoles() => await _Dbcontext.Role.ToListAsync();
     
    }
}

