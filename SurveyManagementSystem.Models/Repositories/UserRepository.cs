using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.BLL.DTOs;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.DAL.Data;



namespace SurveyManagementSystem.DAL.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _Dbcontext;
        public UserRepository(ApplicationDbContext _Dbcontext)
        {
            this._Dbcontext = _Dbcontext;
        }

        public async Task<ServiceRespone> CreateAsync(User user, IList<int> roleIds)
        {
                    
            //throw new NotImplementedException();

            //saving roles for corresponding user 
            if(roleIds != null && roleIds.Any())
            {
                var roles = await _Dbcontext.Role
                                .Where(r => roleIds.Contains(r.Id))
                                .ToListAsync();
                
                foreach(var role in roles) 
                    user.Roles.Add(role); 
            }

            var check = await _Dbcontext.User.FirstOrDefaultAsync(u => u.Name.ToLower() == user.Name.ToLower());
            if (check != null)
                return new ServiceRespone(false, "User already exists");

            await _Dbcontext.AddAsync(user);
            await _Dbcontext.SaveChangesAsync();
            return new ServiceRespone(true, "User added successfully");
        }
        public async Task<ServiceRespone> UpdateAsync(User user, IList<int> roleIds)
        {
            if(roleIds != null && roleIds.Any())
            {
                var roles = await _Dbcontext.Role
                                .Where(r => roleIds.Contains(r.Id))
                                .ToListAsync();

                foreach (var role in roles)
                    user.Roles.Add(role);
            }

            _Dbcontext.Update(user);
            await _Dbcontext.SaveChangesAsync();
            return new ServiceRespone(true, "User update successfully");
        }

        public async Task<ServiceRespone> DeleteAsync(int id)
        {
            var user = await _Dbcontext.User.FindAsync(id);
            if (user == null)
                return new ServiceRespone(false, "User does not exist");

            _Dbcontext.Remove(user);
            await _Dbcontext.SaveChangesAsync();
            return new ServiceRespone(true, "User deleted successfully");
        }

        public async Task<List<User>> GetAsync() => await _Dbcontext.User.AsNoTracking().ToListAsync();


        public async Task<User> GetByIdAsync(int id)
        {

            return await _Dbcontext.User.FindAsync(id);
        }

        //Roles of corresponding users
        public async Task<Dictionary<int, List<RoleDTO>>> GetUserRolesAsync()
        {
            //return await _Dbcontext.User
            //.Include(u => u.Roles)
            //.ToDictionaryAsync(
            //    u => u.Id,
            //    u => u.Roles.ToList()
            //);

            return await _Dbcontext.User
                .Select(u => new
                {
                    u.Id,
                    Roles = u.Roles.Select(r => new RoleDTO
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList()
                })
                .ToDictionaryAsync(
                        u => u.Id,
                        u => u.Roles.ToList()
                );
           

        }
    }
}
  

        
