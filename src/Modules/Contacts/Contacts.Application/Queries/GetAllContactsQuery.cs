using Contacts.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Application.Queries
{
    public record GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>;

}
