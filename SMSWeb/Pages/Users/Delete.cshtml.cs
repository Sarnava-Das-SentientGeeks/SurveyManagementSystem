using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSWeb.Services;
using SurveyManagementSystem.BLL.Entities;
using SurveyManagementSystem.BLL.DTOs;


namespace SMSWeb.Pages.Users
{
    [BindProperties]
    [IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;
 

        public User UserObj { get; set; } = default!;
        
        public DeleteModel(IUserService userService)=> this._userService = userService;
        
       

        public async Task<IActionResult> OnPostDelete()
        {


            ServiceRespone response  = await _userService.DeleteAsync(UserObj.Id);
            if (response.Flag == true)
                TempData["SuccessMessage"] = response.Message;
            else
                TempData["ErrorMessage"] = response.Message;


            return RedirectToPage("/Users/Index");

        } 
    }
}
