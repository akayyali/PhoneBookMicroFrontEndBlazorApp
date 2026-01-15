using Contacts.Contracts.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Contacts.Application.Queries
{
    public record GetAllContactGroupsQuery() : IRequest<IEnumerable<ContactGroupDto>>;
}
