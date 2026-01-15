using PhoneBook.Kernel;

namespace Contacts.Domain.Events
{
    public record ContactUpdatedEvent(Guid ContactId, string ContactName) : DomainEvent;

}
