using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs;


namespace SMSWeb.Pages.Users
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public User UserObj { get; set; } = default!;
        
        public EditModel(IUserService userService)=> _userService = userService;
   
        public void OnGet(int id)
        {

            UserObj = _userService.GetByIdAsync(id).Result;

        }
        
        public async Task<IActionResult> OnPost()
        {
          
            if (ModelState.IsValid)
            {
                ServiceRespone response = await _userService.UpdateAsync(UserObj);
                if (response.Flag == true)
                    TempData["SuccessMessage"] = response.Message;
                else
                    TempData["ErrorMessage"] = response.Message;
            }
            return RedirectToPage("/Users/Index");
        } 
    }
}
