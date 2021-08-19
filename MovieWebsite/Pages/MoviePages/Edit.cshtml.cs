using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieWebsite.Models;

namespace MovieWebsite.Pages.MoviePages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
		public EditModel(ApplicationDbContext db)
		{
            _db = db;
		}
        [BindProperty]
        public Movie Movie { get; set; }
        public async Task OnGet(int id)
        {
            Movie = await _db.Movie.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
		{
            if(ModelState.IsValid)
			{
                var DbMovie = await _db.Movie.FindAsync(Movie.Id);
                DbMovie.Name = Movie.Name;
                DbMovie.Year = Movie.Year;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
		}
    }
}
