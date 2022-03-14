using GraphAPI.Models;
namespace GraphAPI.Queries.Types
{
    public class MovieType : ObjectType<Movie>
    {
        protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
        {
            descriptor
                 .Field(x => x.Title)
                 .Description("title of the movie")
                 .Type<StringType>();

            descriptor
               .Field(x => x.Description)
               .Description("short description of the movie")
               .Type<StringType>();
        }
    }
}
