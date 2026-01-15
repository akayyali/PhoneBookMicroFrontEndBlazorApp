using PhoneBook.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entities
{
    public class ContactGroup : Entity<Guid>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private readonly List<Contact> _contacts = new();
        public virtual IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

        private ContactGroup() { }

        public ContactGroup(string name, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Group name cannot be empty", nameof(name));

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Group name cannot be empty", nameof(name));
            Name = name;
            Description = description;
        }
    }
}
