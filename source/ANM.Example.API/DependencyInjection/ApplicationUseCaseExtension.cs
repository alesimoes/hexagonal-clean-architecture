using ANM.Example.Application.UseCases.BuyStock;
using ANM.Example.Application.UseCases.CreateUser;
using ANM.Example.Application.UseCases.GetTransactions;
using ANM.Example.Application.UseCases.GetWallet;
using ANM.Example.Application.UseCases.SellStock;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class ApplicationUseCaseExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IBuyStockUseCase, BuyStockUseCase>();
            services.AddScoped<ISellStockUseCase, SellStockUseCase>();
            services.AddScoped<IGetWalletUseCase, GetWalletUseCase>();
            services.AddScoped<IGetTransactionsUseCase, GetTransactionsUseCase>();

            return services;
        }
    }
}
