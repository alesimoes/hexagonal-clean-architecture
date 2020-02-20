using ANM.Example.Application.UseCases.BuyStock;
using ANM.Example.Application.UseCases.CreateUser;
using ANM.Example.Application.UseCases.GetTransactions;
using ANM.Example.Application.UseCases.GetWallet;
using ANM.Example.Application.UseCases.SellStock;
using ANM.Example.Domain.Wallets.Events;
using ANM.Example.Infrastructure.EventHandler;
using FluentMediator;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{

    public static class AddMediatorExtension
    {
        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<CreateUserInput>().PipelineAsync()
                        .Call<ICreateUserUseCase>((handler, request) => handler.Execute(request));

                    builder.On<BuyStockInput>().PipelineAsync()
                       .Call<IBuyStockUseCase>((handler, request) => handler.Execute(request));

                    builder.On<SellStockInput>().PipelineAsync()
                    .Call<ISellStockUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetWalletInput>().PipelineAsync()
                    .Call<IGetWalletUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetTransactionsInput>().PipelineAsync()
                    .Call<IGetTransactionsUseCase>((handler, request) => handler.Execute(request));

                    builder.On<WalletUpdatedDomainEvent>().Pipeline()
                      .Call<WalletUpdatedDomainEventInfrastructureHandler>((handler, request) => handler.Execute(request));
                });

            return services;
        }
    }

}
