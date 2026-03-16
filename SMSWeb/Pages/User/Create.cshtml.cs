using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieComponents.Models;
using MovieComponents.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace MovieComponents.Pages.Movies
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly MovieComponentContext _Dbcontext;

        public CreateModel(MovieComponentContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }
        public void OnGet()
        {
          
        }

        [BindProperty]
        
        public MovieTest MovieObj { get; set; } = default!;
        //BindProperty automatically bindsthis object to form details rather than passing the object as parameter to the function below
        //public async Task<IActionResult> OnPostCreate(MovieTest movie)
        public async Task<IActionResult> OnPost()
        {
            //This is for server-side validation
            if (MovieObj.Price > 1000)
            {
                ModelState.AddModelError("MovieObj.Price", "Price is too high");
            }
            if (ModelState.IsValid)
            {
                await _Dbcontext.MovieSet.AddAsync(MovieObj);
                await _Dbcontext.SaveChangesAsync();
                TempData["success"] = "Movie Added Succesfully";
                //TempData["error"] = "Movie Added Succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        } 
    }
}
