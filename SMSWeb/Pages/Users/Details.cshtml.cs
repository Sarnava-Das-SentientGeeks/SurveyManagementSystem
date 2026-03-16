using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs;


namespace SMSWeb.Pages.Users
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;
   
        public IEnumerable<User> UserList { get; set; }
        public DetailsModel(IUserService userService)=> _userService = userService;
   
        public void OnGet()
        {
            UserList = _userService.GetAsync().Result;
        }

     
      
      
        
    }
}
