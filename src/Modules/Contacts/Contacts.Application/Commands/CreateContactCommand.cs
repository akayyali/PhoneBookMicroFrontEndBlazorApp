using Contacts.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Application.Commands
{
    public record CreateContactCommand(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string? CountryCode,
    string? Email,
    string? Street,
    string? City,
    string? State,
    string? PostalCode,
    string? Country,
    string? Company,
    string? JobTitle,
    string? Notes,
    Guid? ContactGroupId) : IRequest<ContactDto>;


}
