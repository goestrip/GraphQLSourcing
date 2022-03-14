using GraphAPI.Models;
namespace GraphAPI.Queries.Types
{
    public class SuperPowerType : ObjectType<SuperPower>
    {
        protected override void Configure(IObjectTypeDescriptor<SuperPower> descriptor)
        {
            descriptor
                .Field(x => x.Power)
                .Description("name of the superpower")
                .Type<StringType>();

            descriptor
               .Field(x => x.Description)
               .Description("What is it that it is :)")
               .Type<StringType>();
        }
    }
}
