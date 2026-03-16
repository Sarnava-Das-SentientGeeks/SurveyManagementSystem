


using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;  


namespace SMSWeb.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)=>_userService = userService;
        

        public IEnumerable<User> UserList { get; set; } = default!;
       
        public void OnGet()
        {
            UserList = _userService.GetAsync().Result;
        }




    }
}
