using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Application.Abstractions.Services;
using ANM.Example.Domain.User;
using ANM.Example.Domain.Wallets;
using ANM.Example.Repositories;
using ANM.Example.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class SqlServerInfrastructureExtension
    {
        public static IServiceCollection AddSQLServerPersistence(
           this IServiceCollection services,
           IConfiguration configuration)
        {

            services.AddDbContext<AnmDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));            

            return services;
        }
    }
}
