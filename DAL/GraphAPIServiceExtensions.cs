using GraphAPI.DAL;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GraphAPIServiceExtensions
    {
        public static IServiceCollection AddArrangoDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>(s =>
            {
                var logService = s.GetRequiredService<ILogger<ApplicationDbContext>>();
                if(logService == null) throw new ArgumentNullException(nameof(logService)); 
                return new ApplicationDbContext(logService);
            });
            return services;
        }
    }
}
