using GraphAPI.DAL;
using GraphAPI.Interfaces;
using GraphAPI.Models;

namespace GraphAPI.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly IApplicationDbContext m_dbContext;
        public SuperHeroRepository(IApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void CreateSuperHero(SuperHero newSuperHero)
        {
            m_dbContext.CreateInCollection(CollectionNames.HeroesDocuments, newSuperHero);
        }

        public Task<SuperHero> CreateSuperHero(string heroName)
        {
            var newHero = new SuperHero
            {
                Name = heroName,
            };
            var reponse = m_dbContext.CreateInCollection(CollectionNames.HeroesDocuments, newHero);
            
            return Task.FromResult(newHero);
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
             var collection = await m_dbContext.GetDocumentsOfCollection<SuperHero>(CollectionNames.HeroesDocuments);
            
            if(collection is not null) return collection;
            else return new List<SuperHero>();
        }

        public async Task<List<Movie>> GetMovieWithHero(SuperHero hero)
        {
            return await m_dbContext.RunAqlQuery<Movie>($@"for hero in superheroes
                                                filter hero.name=='{hero.Name}'
                                                for movie in outbound hero starsin
                                                return movie");

            
        }
    }
}
