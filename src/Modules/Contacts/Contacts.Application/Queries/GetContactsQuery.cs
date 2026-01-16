using Contacts.Contracts.DTOs;
using Contacts.Domain.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Application.Queries
{
    public record GetContactsQuery(GetContactsSpecification specification) : IRequest<IEnumerable<ContactDto>>;

}
