using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    }
}
