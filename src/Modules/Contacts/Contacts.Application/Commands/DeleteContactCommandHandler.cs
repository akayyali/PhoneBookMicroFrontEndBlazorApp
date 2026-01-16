using Contacts.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contacts.Application.Commands
{
    public class DeleteContactCommandHandler(ContactsDbContext _contactsDBContext, ILogger<DeleteContactCommandHandler> _logger) : IRequestHandler<DeleteContactCommand>
    {
        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handling DeleteContactCommand for ContactId: {ContactId}", request.ContactId);

            var contact = _contactsDBContext.Contacts.FirstOrDefault(c => c.Id == request.ContactId);
            if (contact != null)
            {
                _contactsDBContext.Contacts.Remove(contact);
                await _contactsDBContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
