using GraphAPI.Models;

namespace GraphAPI.Interfaces
{
    public interface ISuperHeroRepository
    {
        public Task<List<SuperHero>> GetAllHeroes();
        public Task<SuperHero> CreateSuperHero(string heroName);

        public Task<List<Movie>> GetMovieWithHero(SuperHero hero);
    }
}
