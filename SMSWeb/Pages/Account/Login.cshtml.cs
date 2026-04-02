using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;

namespace SMSWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential {  get; set; }
        public void OnGet()
        {
            this.credential = new Credential { UserName = "admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            //Verify the credential
            if(credential.UserName == "admin" && credential.Password=="password")
            {
                //Creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email,"admin@mywebsite.com"),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim("Department","HR"),
                    new Claim("Admin","true"),
                    new Claim("Manager","true")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            else
                return Page();
        }

        public class Credential
        {
            [Required,Display(Name="User Name")]
            public string UserName { get; set; }

            [Required,DataType(DataType.Password)]
            public string Password { get; set; }    

        } 
    }
}
