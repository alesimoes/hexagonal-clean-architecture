using ANM.Example.Repositories.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class MongoDbInfrastructureExtension
    {
        public static IServiceCollection AddMongoDbPersistence(
          this IServiceCollection services,
          IConfiguration configuration)
        {

            var config = new ServerConfig();
            configuration.Bind(config);

            services.AddScoped<TransactionDbContext>(s => new TransactionDbContext(config.MongoDB));
           ;
            return services;
        }
    }
}
