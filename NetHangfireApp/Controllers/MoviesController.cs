using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetHangfireDB;
using NetHangfireDB.Entities;

namespace NetHangfireApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly NetHangfireDBContext _context;
        private readonly string _apiKey;
        public MoviesController(NetHangfireDBContext context, IConfiguration configuration)
        {
            _context = context;
            _apiKey = configuration["Apikey"];
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string s = "", string apikey = "")
        {
            if (!string.IsNullOrEmpty(apikey) && apikey == _apiKey)
            {
                var movies = _context.Movies.AsQueryable();
                if (!string.IsNullOrEmpty(s))
                {
                    movies = movies.Where(m => m.Title == s);
                }
                return await movies.ToListAsync();
            }
            return Unauthorized();
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
    }
}
