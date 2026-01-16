using System.Net;

namespace Contacts.Contracts.DTOs
{
    public class ContactDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; init; }
        
        public string CountryCode { get; init; }
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
