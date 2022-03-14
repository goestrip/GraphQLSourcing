using GraphAPI.Models;

namespace GraphAPI.Interfaces
{
    public interface IMovieRepository
    {
        public void CreateMovie(Models.Movie movie);
        public Task<List<Movie>> GetAllMovies();
    }
}
