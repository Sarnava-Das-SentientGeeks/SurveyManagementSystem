using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieComponents.Models;
using MovieComponents.Data;
using Microsoft.AspNetCore.Authorization;



namespace MovieComponents.Pages.Movies
{
    [BindProperties]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        private readonly MovieComponentContext _Dbcontext;

        public MovieTest MovieObj { get; set; } = default!;
        
        public DeleteModel(MovieComponentContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }
        public void OnGet(int? id)
        {

            MovieObj = _Dbcontext.MovieSet.FirstOrDefault(u => u.Id == id); //Returns the 1st record of the resultset or default value which is none

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
           
            //if(ModelState.IsValid()) does not work for disabled input fields so we don't use it here
            //This is not used since the id is passed as parameter in the handler: var movieDel = _Dbcontext.MovieSet.Find(MovieObj.Id);
            var movieDel = _Dbcontext.MovieSet.Find(id);
            if (movieDel != null)
                {

                    _Dbcontext.MovieSet.Remove(movieDel);
                    await _Dbcontext.SaveChangesAsync();
                    TempData["success"] = "Movie Deleted Successfully";

                    // Return a status code instead of a Page (since JS is handling the response)
                    return new StatusCodeResult(200);
                   //return RedirectToPage("Index");

            }
            return new StatusCodeResult(500);
    
        } 
    }
}
