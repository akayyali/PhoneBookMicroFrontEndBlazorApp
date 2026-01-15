using PhoneBook.Kernel;
using System.Net;

namespace Contacts.Domain.Entities
{
    public class Contact : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email? Email { get; private set; }
        public Address? Address { get; private set; }
        public string? Company { get; private set; }
        public string? JobTitle { get; private set; }
        public string? Notes { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsFavorite { get; private set; }
        public Guid? ContactGroupId { get; private set; }
        public virtual ContactGroup? ContactGroup { get; private set; }

        private Contact() { }

        public Contact(string firstName, string lastName, PhoneNumber phoneNumber,
            Email? email = null, Address? address = null, string? company = null,
            string? jobTitle = null, Guid? contactGroupId = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty", nameof(lastName));

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email;
            Address = address;
            Company = company;
            JobTitle = jobTitle;
            ContactGroupId = contactGroupId;
            CreatedAt = DateTime.UtcNow;
            IsFavorite = false;
        }

        public string FullName => $"{FirstName} {LastName}";

        public void Update(string firstName, string lastName, PhoneNumber phoneNumber,
            Email? email = null, Address? address = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateProfessionalInfo(string? company, string? jobTitle)
        {
            Company = company;
            JobTitle = jobTitle;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateNotes(string? notes)
        {
            Notes = notes;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ToggleFavorite()
        {
            IsFavorite = !IsFavorite;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignToGroup(Guid? groupId)
        {
            ContactGroupId = groupId;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
