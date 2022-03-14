using GraphAPI.Interfaces;
using GraphAPI.Models;
using GraphAPI.Queries.Types;

namespace GraphAPI.Queries
{
    
    public record AddHeroInput(string name, int height);

    public class AddHeroPayload
    {
        public AddHeroPayload(SuperHero hero)
        {
            Hero = hero;
        }
        public SuperHero Hero { get; }
    }

    public class Mutation
    {
        public async Task<AddHeroPayload> AddHeroAsync(
                AddHeroInput input, [Service] ISuperHeroRepository heroRepo)
        {
            var hero = await heroRepo.CreateSuperHero(input.name);

            return new AddHeroPayload(hero);
        }
    }
}
