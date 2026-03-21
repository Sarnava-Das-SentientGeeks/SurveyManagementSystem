
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMSWeb.Services;

using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs;



namespace SMSWeb.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService roleService;
    

        public IndexModel(IUserService userService, IRoleService roleService) { _userService = userService; this.roleService = roleService;  } 
        

        public IEnumerable<User> UserList { get; set; } = default!;

        public IEnumerable<Role> RoleList { get; set; } 
        public Dictionary<int,List<RoleDTO>> UserRoleList { get; set; }

        public async Task OnGet()
        {
    
            UserList = _userService.GetAsync().Result;
            UserRoleList = await _userService.GetUserRolesAsync();


            //This gives all roles of all users
            //RoleList = await _context.Users
            //           .SelectMany(u => u.Roles)
            //           .ToListAsync();


            //This gives roles of each user
            //var users = await _context.Users
            //    .Include(u => u.Roles)
            //    .ToListAsync();
            //foreach (var user in users)
            //      var roles = user.Roles; // each user’s roles

        }

        public async Task<User> GetByIdAsync(int id) => await _userService.GetByIdAsync(id);


        public async Task<IActionResult> OnGetGetById(int id)
        {

            var user = await GetByIdAsync(id);

            //This is recommended for Razor pages but if MVC service is enabled then this will work too:return Partial("_EditView", user);
            return new PartialViewResult
            {
                ViewName = "_EditView",
                ViewData = new ViewDataDictionary<User>(ViewData, user)
            };
        }

        public async Task<IActionResult> OnGetCreateModal()
        {
            RoleList = await roleService.GetRoles();

            ViewData["RoleList"] = RoleList;

            return new ViewResult
            {
                ViewName = "Create",
                ViewData = ViewData
            };
        }

    }
}
