using PhoneBook.Kernel;

namespace Contacts.Domain.Events
{
    public record ContactDeletedEvent(Guid ContactId, string ContactName) : DomainEvent;

}
