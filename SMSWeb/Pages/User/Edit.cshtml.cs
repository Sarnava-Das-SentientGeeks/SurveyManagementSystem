using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieComponents.Models;
using MovieComponents.Data;
using Microsoft.EntityFrameworkCore;


namespace MovieComponents.Pages.Movies
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly MovieComponentContext _Dbcontext;

        public MovieTest MovieObj { get; set; } = default!;
        
        public EditModel(MovieComponentContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }
        public void OnGet(int id)
        {
            //MovieObj = _Dbcontext.MovieSet.Find(id); //Searches by primary key
            //MovieObj = _Dbcontext.MovieSet.FirstOrDefault(id); //Returns the 1st record of the resultset or default value which is null
            //MovieObj = _Dbcontext.MovieSet.Single(id);//Used when there is single record but multiple records will throw error
            //MovieObj = _Dbcontext.MovieSet.SingleOrDefault(id);//Returns single record or default value which is null
            //MovieObj = _Dbcontext.MovieSet.Where(u => u.Id == id).FirstOrDefault();

            MovieObj = _Dbcontext.MovieSet.Find(id);

        }
        
        public async Task<IActionResult> OnPost()
        {
            if (MovieObj.Price > 1000)
            {
                ModelState.AddModelError("MovieObj.Price", "Price is too high");
            }
            if (ModelState.IsValid)
            {
                 _Dbcontext.MovieSet.Update(MovieObj);
                await _Dbcontext.SaveChangesAsync();
                TempData["success"] = "Movie Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        } 
    }
}
