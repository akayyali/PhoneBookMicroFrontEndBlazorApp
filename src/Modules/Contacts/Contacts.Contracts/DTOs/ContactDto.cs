using System.Net;

namespace Contacts.Contracts.DTOs
{
    public class ContactDto
    {
        //public ContactDto(string firstName, string lastName, string phoneNumber, string email, AddressDto? address, string? company, string? jobTitle, string? notes, DateTime createdAt, DateTime? updatedAt, bool isFavorite, Guid? contactGroupId, ContactGroupDto? contactGroup)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PhoneNumber = phoneNumber;
        //    Email = email;
        //    Address = address;
        //    Company = company;
        //    JobTitle = jobTitle;
        //    Notes = notes;
        //    CreatedAt = createdAt;
        //    UpdatedAt = updatedAt;
        //    IsFavorite = isFavorite;
        //    ContactGroupId = contactGroupId;
        //    ContactGroup = contactGroup;
        //}

        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public AddressDto? Address { get; init; }
        public string? Company { get; init; }
        public string? JobTitle { get; init; }
        public string? Notes { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsFavorite { get; init; }
        public Guid? ContactGroupId { get; init; }
        public ContactGroupDto? ContactGroup { get; init; }
    }
}
