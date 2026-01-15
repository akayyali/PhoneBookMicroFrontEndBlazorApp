using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Contracts.DTOs
{
    public record AddressDto
    {
        public string Street { get; init; }
        public string Suburb { get; init ; }
        public string? State { get; init; }
        public string PostCode { get; init; }
        public string Country { get; init; }
    }
}
