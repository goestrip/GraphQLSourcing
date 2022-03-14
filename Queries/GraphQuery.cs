using GraphAPI.Interfaces;
using GraphAPI.Queries.Types;

namespace GraphAPI.Queries
{
    public class GraphQuery
    {
        //public IQueryable<SuperHero> GetSuperHeroes([Service] ISuperHeroRepository repo)
        //{
        //    return new List<SuperHero>().AsQueryable();
        //} 

    }


    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor )
        {
            descriptor.Name(OperationTypeNames.Query);


            descriptor
                .Field("heroes")
                .Type<ListType<SuperHeroType>>()
                .Resolve(context =>
                {
                    var repo = context.Service<ISuperHeroRepository>();
                    return repo.GetAllHeroes();
                })
                .Description("get all the list of ze superheroes");

            descriptor
                .Field("Movies")
                .Type < ListType<MovieType>>()
                .Resolve(context =>
                {
                    var repo = context.Service<IMovieRepository>();
                    return repo.GetAllMovies();
                })
                .Description("get all the list of ze super movies");

            descriptor
                .Field("Powers")
                .Type<ListType<SuperPowerType>>()
                .Resolve(context =>
                {
                    var repo = context.Service<ISuperPowerRepository>();
                    if (repo is not null) return repo.GetAllPowers();
                    else return null;
                });

        }
    }
}
