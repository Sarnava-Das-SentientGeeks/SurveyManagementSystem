

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieComponents.Data;
using MovieComponents.Models;

namespace MovieComponents.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieComponentContext _dbcontext;

        public IndexModel(MovieComponentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<MovieTest> MovieList { get; set; } = default!;
        //MovieList contains multiple objects of MovieTest i.e multiple records of MovieTest model class
        public void OnGet()
        {
            MovieList = _dbcontext.MovieSet; 
        }


    }
}
