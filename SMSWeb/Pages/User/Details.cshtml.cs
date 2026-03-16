using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieComponents.Models;
using MovieComponents.Data;


namespace MovieComponents.Pages.Movies
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly MovieComponentContext _Dbcontext;
   
        public IEnumerable<MovieTest> MovieList { get; set; }
        public DetailsModel(MovieComponentContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }
        public void OnGet()
        {
            MovieList = _Dbcontext.MovieSet;
        }

     
      
      
        
    }
}
