using ANM.Core.Domain.Abstractions.Events;
using FluentMediator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANM.Example.EventPublisher
{
    public class EventPubisher : IEventPublisher
    {
        private readonly IMediator _mediator;

        public EventPubisher(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public async Task Publish(IEnumerable<DomainEvent> domainEvents)
        {
            await Task.Run(() =>
            {
                var orderedEvents = domainEvents.OrderBy(d => d.CreatedDate);
                foreach (var domainEvent in orderedEvents)
                {
                    this._mediator.Publish(domainEvent);
                }
            });
        }
    }
}
