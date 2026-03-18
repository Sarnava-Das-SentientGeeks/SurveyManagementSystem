
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

        public IndexModel(IUserService userService)=>_userService = userService;
        

        public IEnumerable<User> UserList { get; set; } = default!;

        //Getting roles for users
        public IEnumerable<RoleUserDTO> RoleList { get; set; } = default!;

        public void OnGet()
        {
            UserList = _userService.GetAsync().Result;
            //UserList = await _userService.GetAsync();
        }

        public async Task<User> GetByIdAsync(int id) => await _userService.GetByIdAsync(id);


        public async Task<IActionResult> OnGetGetById(int id)
        {

            var user = await GetByIdAsync(id);

            //This is used recommended for Razor pages but if MVC service is enabled then this will work too:return Partial("_EditView", user);
            return new PartialViewResult
            {
                ViewName = "_EditView",
                ViewData = new ViewDataDictionary<User>(ViewData, user)
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
