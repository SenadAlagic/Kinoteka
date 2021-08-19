using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieWebsite.Models;

namespace MovieWebsite.Pages.MoviePages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
		public IndexModel(ApplicationDbContext db)
		{
            _db = db;
		}
        public IEnumerable<Movie> Movies { get; set; } 
		public async Task OnGet()
        {
            Movies = await _db.Movie.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
		{
            var Movie = await _db.Movie.FindAsync(id);
            if(Movie==null)
			{
                return NotFound();
			}
            _db.Movie.Remove(Movie);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
		}
        public async Task<IActionResult> OnPostRent(int id)
		{
            var Movie = await _db.Movie.FindAsync(id);
            Movie.Rented = !(Movie.Rented);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
		}
        //public async Task<IActionResult> OnPostGiveback(int id)
        //{
        //    var Movie = await _db.Movie.FindAsync(id);
        //    Movie.Rented = false;
        //    await _db.SaveChangesAsync();
        //    return RedirectToPage("Index");
        //}
    }
}
