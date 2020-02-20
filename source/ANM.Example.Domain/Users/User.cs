using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Domain.User.Events;
using ANM.Example.Domain.ValueObjects;
using ANM.Example.Domain.Wallets;

namespace ANM.Example.Domain.User
{
    public class User : AggregateRoot
    {
        public int UserId { get; protected set; }
        public Name Name { get; protected set; }

        public Email Email { get; protected set; }

        public Wallet Wallet { get; protected set; }

        private User()
        {
            Register<UserCreatedDomainEvent>(When);
        }

        internal static User Create(Name name, Email email)
        {
            var user = new User();
            user.Name = name;
            user.Email = email;
            user.Raise(UserCreatedDomainEvent.Create(user));
            return user;
        }


        protected void When(UserCreatedDomainEvent @event)
        {
            this.UserId = @event.User.UserId;
            this.Name = @event.User.Name;
            this.Email = @event.User.Email;
            this.Wallet = Wallet.Create(@event.User);
        }
    }
}
