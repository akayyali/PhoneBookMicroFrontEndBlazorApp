using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Contracts.DTOs
{
    public class ContactGroupDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}
