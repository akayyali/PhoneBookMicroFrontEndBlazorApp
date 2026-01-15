using Contacts.Contracts.DTOs;
using Contacts.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.Application.Queries
{
    public class GetAllContactGroupsQueryHandler(ContactsDbContext _contactsDBContext) : IRequestHandler<GetAllContactGroupsQuery, IEnumerable<ContactGroupDto>>
    {
        public async Task<IEnumerable<ContactGroupDto>> Handle(GetAllContactGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _contactsDBContext.ContactGroups
                .Select(g => new ContactGroupDto { Id = g.Id, Name = g.Name, Description = g.Description })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
