using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Kernel
{
    public abstract record DomainEvent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime RaisedOn { get; init; } = DateTime.UtcNow;
    }
}
