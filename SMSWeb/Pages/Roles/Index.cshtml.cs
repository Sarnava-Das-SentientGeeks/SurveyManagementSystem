using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;

namespace SMSWeb.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IRoleService roleService;
        public IndexModel(IRoleService roleService) => this.roleService = roleService;

        public IEnumerable<Role> RoleList { get; set; }


        public void OnGet()
        {
            RoleList = roleService.GetRoles().Result;
        }
             

        public async Task<IActionResult> OnGetEditModal(int id)
        {
            var data = await roleService.GetRoleById(id);

            return new ViewResult
            {
                ViewName = "Edit",
                ViewData = new ViewDataDictionary<Role>(ViewData, data)
            };

        }

        public async Task<IActionResult> OnGetCreateModal()
        {
            return new ViewResult
            {
                ViewName = "Create",
                ViewData = null
            };
        }
   
    }
}
