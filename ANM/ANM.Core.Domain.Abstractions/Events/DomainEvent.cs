using System;

namespace ANM.Core.Domain.Abstractions.Events
{
    public class DomainEvent
    {
        public DateTime CreatedDate { get; private set; }


        public DomainEvent()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
