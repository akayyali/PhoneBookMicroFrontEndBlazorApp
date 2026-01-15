using PhoneBook.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Events
{
    public record ContactCreatedEvent(Guid ContactId, string ContactName) : DomainEvent;

}
