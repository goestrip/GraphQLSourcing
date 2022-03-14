using GraphAPI.Interfaces;
using GraphAPI.Models;

namespace GraphAPI.Queries.Types
{
    public class SuperHeroType : ObjectType<SuperHero>
    {
        protected override void Configure(IObjectTypeDescriptor<SuperHero> descriptor)
        {
            descriptor
                .Field(x => x.Name)
                .Type<StringType>();

            descriptor
                .Field(x => x.Height)
                .Description("the height of the dude")
                .Type<IntType>();

            descriptor
                .Field("movies")
                .Description("movies this hero appears in")
                .Resolve(context =>
                {
                    var repoHero = context.Service<ISuperHeroRepository>();
                    var parent = context.Parent<SuperHero>();
                    return repoHero.GetMovieWithHero(parent);
                });
          
        }
    }
}
