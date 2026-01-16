using Contacts.Contracts.DTOs;
using Contacts.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Kernel.Data.Specification;

namespace Contacts.Application.Queries
{
    public class GetContactsQueryHandler(ContactsDbContext _contactsDBContext) : IRequestHandler<GetContactsQuery, IEnumerable<ContactDto>>
    {
        public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {

            var contacts = _contactsDBContext.Contacts.AsQueryable().ApplySpecification(request.specification)
                .Select(x => new ContactDto()
            {
                Id = x.Id,
                Company = x.Company,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber.FormattedNumber,
                CountryCode = x.PhoneNumber.CountryCode?? "",
                JobTitle = x.JobTitle,
                Notes = x.Notes,
                ContactGroupId = x.ContactGroupId,
                ContactGroup = x.ContactGroup != null ? new ContactGroupDto()
                {
                    Name = x.ContactGroup.Name,
                    Description = x.ContactGroup.Description
                } : null,
                Email = x.Email != null ? x.Email.Address : string.Empty,
                Address = x.Address != null ? new AddressDto()
                {
                    Street = x.Address.Street,
                    Suburb = x.Address.Suburb,
                    State = x.Address.State,
                    PostCode = x.Address.PostCode,
                    Country = x.Address.Country
                } : null,
            });
                //.AsNoTracking();

            return await contacts.ToListAsync();
        }
    }

}
