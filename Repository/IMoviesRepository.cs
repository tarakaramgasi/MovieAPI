using EntityCL;
namespace Repository
{
    public interface IMoviesRepository
    {
        public Movie GetMovieById(int id);
        public IEnumerable<Movie> GetMoviesByGenre(string genre);
        public IEnumerable<Movie> GetMovies();

        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(int id);
    }
}
