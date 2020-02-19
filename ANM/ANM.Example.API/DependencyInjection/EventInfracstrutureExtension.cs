using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.EventPublisher;
using ANM.Example.Infrastructure.EventHandler;
using Microsoft.Extensions.DependencyInjection;

namespace ANM.Example.API.DependencyInjection
{
    public static class EventInfracstrutureExtension
    {
        public static IServiceCollection AddEventInfracstruture(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, EventPubisher>();
            services.AddScoped<WalletUpdatedDomainEventInfrastructureHandler>();

            return services;
        }
    }
}
