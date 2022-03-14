using GraphAPI.Models;

namespace GraphAPI.Migrations
{
    public class GenerateData
    {
        public List<SuperHero> heroes = new List<SuperHero>();

        public GenerateData()
        {
            heroes.Add(new SuperHero
            {
                Name = "SuperMan",
                Description = "l'homme volant en moulbite",
                Height = "1.90",
            }); ;
        }
    }
}
