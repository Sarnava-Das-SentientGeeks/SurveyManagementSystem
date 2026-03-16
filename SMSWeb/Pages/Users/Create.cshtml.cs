using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs; 

namespace SMSWeb.Pages.Users
{

    public class CreateModel : PageModel
    {
        private readonly IUserService userService;

        public CreateModel(IUserService  userService)=>this.userService = userService;

  

        [BindProperty]        
        public User UserObj{ get; set; }

      
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                ServiceRespone response = await userService.CreateAsync(UserObj);
                if(response.Flag == true)
                    TempData["SuccessMessage"]  = response.Message;
                else
                    TempData["ErrorMessage"]  = response.Message;

            }
            return RedirectToPage("/Users/Index");
        } 
    }
}
