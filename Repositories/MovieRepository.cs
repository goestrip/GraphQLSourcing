using GraphAPI.DAL;
using GraphAPI.Interfaces;
using GraphAPI.Models;

namespace GraphAPI.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly IApplicationDbContext m_dbContext;

        public MovieRepository(IApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var collection = await m_dbContext.GetDocumentsOfCollection<Movie>(CollectionNames.MoviesDocuments);
            if (collection is not null)
                return collection;

            else return new List<Movie>();
        }
    }
}
