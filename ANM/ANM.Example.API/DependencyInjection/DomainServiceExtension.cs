using ANM.Example.Domain.User.Services;
using ANM.Example.Domain.Wallets.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();

            return services;
        }
    }
}
