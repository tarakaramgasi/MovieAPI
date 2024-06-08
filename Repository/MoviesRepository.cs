using EntityCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        //Question: Why am i getting error at IMoviesRepository if we do not implement atleast one method from interface.
        private readonly MovieContext _dbContext = null!;
        public MoviesRepository(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie GetMovieById(int id) => _dbContext.Movies.FirstOrDefault(movie => movie.Id == id);


        public IEnumerable<Movie> GetMoviesByGenre(string genre) => _dbContext.Movies.Where(movie => movie.Genre == genre);


        public IEnumerable<Movie> GetMovies() =>  _dbContext.Movies.ToList();

        public void AddMovie(Movie movie)
        { 
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            
        }
        public void UpdateMovie(Movie movie)
        {
            _dbContext.Entry(movie).State= EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(movie => movie.Id==id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}
