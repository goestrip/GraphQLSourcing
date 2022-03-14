using GraphAPI.Models;

namespace GraphAPI.Interfaces
{
    public interface ISuperPowerRepository
    {
        public void CreateSuperPower(SuperPower superPower);
        public Task<List<SuperPower>> GetAllPowers();
    }
}
