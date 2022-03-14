using GraphAPI.DAL;
using GraphAPI.Interfaces;
using GraphAPI.Models;

namespace GraphAPI.Repositories
{
    public class SuperPowerRepository: ISuperPowerRepository
    {
        private readonly IApplicationDbContext m_dbContext;

        public SuperPowerRepository(IApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void CreateSuperPower(SuperPower superPower)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SuperPower>> GetAllPowers()
        {
            var collection = await m_dbContext.GetDocumentsOfCollection<SuperPower>("superpowers");

            if (collection is not null) return collection;
            else return new List<SuperPower>();
        }
    }
}
