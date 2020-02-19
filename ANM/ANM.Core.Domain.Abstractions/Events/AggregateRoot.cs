using System;
using System.Collections.Generic;

namespace ANM.Core.Domain.Abstractions.Events
{
    public abstract class AggregateRoot
    {
        private readonly Dictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();


        protected void Register<T>(Action<T> when)
        {
            handlers.Add(typeof(T), e => when((T)e));
        }

        public void Raise(DomainEvent domainEvent)
        {
            handlers[domainEvent.GetType()](domainEvent);
            domainEvents.Add(domainEvent);
        }

        public IReadOnlyCollection<DomainEvent> GetEvents()
        {
            return domainEvents;
        }

        public void Apply(DomainEvent domainEvent)
        {
            handlers[domainEvent.GetType()](domainEvent);
        }
    }
}
