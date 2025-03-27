using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Pages.Movies
{
    public class Director_MovieModel : PageModel
    {
        private readonly PePrn222TrialContext _context;
        private readonly IHubContext<MovieHub> _hubContext;

        public Director_MovieModel(PePrn222TrialContext context, IHubContext<MovieHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public List<Director> Directors { get; set; }
        public List<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedDirectorId { get; set; }

        public void OnGet()
        {
            Directors = _context.Directors.ToList();

            var moviesQuery = _context.Movies
                .Include(m => m.Director)
                .Include(m => m.Producer)
                .Include(m => m.Stars)
                .AsQueryable();

            if (SelectedDirectorId.HasValue)
            {
                moviesQuery = moviesQuery.Where(m => m.DirectorId == SelectedDirectorId);
            } 

            Movies = moviesQuery.ToList();  

        }

        // delete
        public async Task<IActionResult> OnGetDeleteAsync(int movieId)
        {
            var moviesQuery = await _context.Movies
                .Include(m => m.Stars)
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == movieId);

            if (moviesQuery == null)
            {
                return NotFound();
            }

            moviesQuery.Stars.Clear();
            moviesQuery.Genres.Clear();

            _context.Movies.Remove(moviesQuery);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("RefreshPage", movieId);

            return RedirectToPage(new { SelectedDirectorId });

        }
    }
}
