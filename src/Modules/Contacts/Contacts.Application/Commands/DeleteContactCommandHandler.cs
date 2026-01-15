using Contacts.Infrastructure;
using MediatR;

namespace Contacts.Application.Commands
{
    public class DeleteContactCommandHandler(ContactsDbContext _contactsDBContext) : IRequestHandler<DeleteContactCommand>
    {
        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _contactsDBContext.Contacts.FirstOrDefault(c => c.Id == request.ContactId);
            if (contact != null)
            {
                _contactsDBContext.Contacts.Remove(contact);
                await _contactsDBContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
