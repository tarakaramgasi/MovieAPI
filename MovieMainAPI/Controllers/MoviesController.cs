using Asp.Versioning;
using EntityCL;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace MovieMainAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesRepository _repository = null;
        public MoviesController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            if (_repository.GetMovies().ToList().Count == 0)
            {
                return null;
            }
            await Task.Delay(1000);
            return _repository.GetMovies();
        }

        [Route("GetMoviesById")]
        [HttpGet]
        public async Task<Movie> GetMoviesById(int id)
        {
            if(_repository.GetMovieById(id) == null)
            {
                return null;
            }
            await Task.Delay(1000);
            return _repository.GetMovieById(id);
        }

        [Route("GetMoviesByGenre")]
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(string genre)
        {
            if (_repository.GetMoviesByGenre(genre) == null)
            {
                return null;
            }
            await Task.Delay(1000);
            return _repository.GetMoviesByGenre(genre);
        }
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await Task.Delay(1000);
            _repository.AddMovie(movie);
            return CreatedAtAction(nameof(GetMoviesById), new { id = movie.Id }, movie);
        }
        [HttpPut]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if(id != movie.Id)
            {
                return BadRequest();
            }
            await Task.Delay(1000);
            _repository.UpdateMovie(movie);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await Task.Delay(1000);
            _repository.DeleteMovie(id);
            return NoContent();
        }
    }
}

