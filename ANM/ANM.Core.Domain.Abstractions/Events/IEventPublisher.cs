using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANM.Core.Domain.Abstractions.Events
{
    public interface IEventPublisher
    {
        Task Publish(IEnumerable<DomainEvent> domainEvents);
    }
}
