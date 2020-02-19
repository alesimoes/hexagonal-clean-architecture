using ANM.Example.API.UseCases.BuyStock;
using ANM.Example.API.UseCases.CreateUser;
using ANM.Example.API.UseCases.GetTransactions;
using ANM.Example.API.UseCases.GetWallet;
using ANM.Example.API.UseCases.SellStock;
using ANM.Example.Application.UseCases.BuyStock;
using ANM.Example.Application.UseCases.CreateUser;
using ANM.Example.Application.UseCases.GetTransactions;
using ANM.Example.Application.UseCases.GetWallet;
using ANM.Example.Application.UseCases.SellStock;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class PresenterExtension
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateUserPresenter, CreateUserPresenter>();
            services.AddScoped<ICreateUserOutput>(x => x.GetRequiredService<CreateUserPresenter>());

            services.AddScoped<BuyStockPresenter, BuyStockPresenter>();
            services.AddScoped<IBuyStockOutput>(x => x.GetRequiredService<BuyStockPresenter>());


            services.AddScoped<SellStockPresenter>();
            services.AddScoped<ISellStockOutput>(x => x.GetRequiredService<SellStockPresenter>());

            services.AddScoped<GetTransactionsPresenter>();
            services.AddScoped<IGetTransactionsOutput>(x => x.GetRequiredService<GetTransactionsPresenter>());

            services.AddScoped<GetWalletPresenter>();
            services.AddScoped<IGetWalletOutput>(x => x.GetRequiredService<GetWalletPresenter>());


            return services;
        }
    }
}
