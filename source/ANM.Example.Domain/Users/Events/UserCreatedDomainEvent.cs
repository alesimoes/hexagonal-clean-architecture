using ANM.Core.Domain.Abstractions.Events;

namespace ANM.Example.Domain.User.Events
{
    public class UserCreatedDomainEvent : DomainEvent
    {
        public UserCreatedDomainEvent(User entity) : base()
        {
            this.User = entity;
        }

        public User User { get; }

        public static UserCreatedDomainEvent Create(User entity)
        {
            UserCreatedDomainEvent domainEvent = new UserCreatedDomainEvent(entity);
            return domainEvent;
        }
    }
}
