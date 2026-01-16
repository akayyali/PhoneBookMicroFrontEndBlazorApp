using Contacts.Contracts.DTOs;
using Contacts.Domain;
using Contacts.Domain.Entities;
using Contacts.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Contacts.Application.Commands
{
    public class CreateContactCommandHandler(ContactsDbContext _contactsDBContext, ILogger<CreateContactCommandHandler> _logger) : IRequestHandler<CreateContactCommand, ContactDto>
    {
        public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handling CreateContactCommand for {FirstName} {LastName}", request.FirstName, request.LastName);

            var phoneNumber = new PhoneNumber(request.PhoneNumber, request.CountryCode);

            Email? email = null;
            if (!string.IsNullOrWhiteSpace(request.Email))
                email = new Email(request.Email);

            Address? address = null;
            if (!string.IsNullOrWhiteSpace(request.Street) &&
                !string.IsNullOrWhiteSpace(request.City) &&
                !string.IsNullOrWhiteSpace(request.PostalCode) &&
                !string.IsNullOrWhiteSpace(request.Country))
            {
                address = new Address(request.Street, request.City, request.PostalCode,
                    request.Country, request.State);
            }

            var contact = new Contact(
                request.FirstName,
                request.LastName,
                phoneNumber,
                email,
                address,
                request.Company,
                request.JobTitle,
                request.ContactGroupId);

            if (!string.IsNullOrWhiteSpace(request.Notes))
                contact.UpdateNotes(request.Notes);

            _contactsDBContext.Contacts.Add(contact);
            await _contactsDBContext.SaveChangesAsync();

            var freshContact = await _contactsDBContext.Contacts
                .Include(e => e.ContactGroup)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == contact.Id, cancellationToken);

            return MapToDto(freshContact);
        }

        private static ContactDto MapToDto(Contact contact) => new()
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber.FormattedNumber,
            Email = contact.Email?.Address ?? "",
            Address = new AddressDto
            {
                Country = contact.Address?.Country ?? "",
                PostCode = contact.Address?.PostCode ?? "",
                State = contact.Address?.State ?? "",
                Street = contact.Address?.Street ?? "",
                Suburb = contact.Address?.Suburb ?? ""
            },
            Company = contact.Company,
            JobTitle = contact.JobTitle,
            Notes = contact.Notes,
            IsFavorite = contact.IsFavorite,
            CreatedAt = contact.CreatedAt,
            UpdatedAt = contact.UpdatedAt,
            ContactGroupId = contact.ContactGroupId,


            // Only set ContactGroup if ID is not null
            ContactGroup = contact.ContactGroupId != null? 
            new ContactGroupDto
                {
                    Description = contact.ContactGroup?.Description,
                    Name = contact.ContactGroup?.Name?? ""
                }
            : null
        };
    }

}
