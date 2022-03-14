using GraphAPI.DAL;
using GraphAPI.DAL.EventStore;
using GraphAPI.Interfaces;
using GraphAPI.Queries;
using GraphAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
builder.Services.AddScoped<ISuperPowerRepository, SuperPowerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddArrangoDb(builder.Configuration);

//builder.Services.AddSingleton<EventStoreContext>(s =>
//{
//    string? eventConnection = builder.Configuration.GetConnectionString("eventStore.db");
//    return new EventStoreContext(EventStoreContext);
//});
builder.Services.AddSingleton<EventStoreContext>();


builder.Services.AddGraphQLServer()
    .AddQueryType<QueryType>()
    .AddMutationType<Mutation>()
    .AddMutationConventions(applyToAllMutations: true);



var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapGet("/dbInit", () =>
{
    var scope = app.Services.CreateScope();
    ISuperHeroRepository? superHeroRepo = scope.ServiceProvider.GetRequiredService<ISuperHeroRepository>();
    if(superHeroRepo is not null)
    {
        return superHeroRepo.GetAllHeroes();
    }
    else return null;
});

app.MapGet("/EventDB", () =>
{
    var scope = app.Services.CreateScope();
    EventStoreContext eventStoreContext = scope.ServiceProvider.GetRequiredService<EventStoreContext>();
    eventStoreContext.SendTimeEvent();
});

app.MapGraphQL("/graphql");

app.Run();

