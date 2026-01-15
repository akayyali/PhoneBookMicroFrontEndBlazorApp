using PhoneBook.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entities
{
    public record Address : ValueObject
    {
        public string Street { get; private set; }
        public string Suburb { get; private set; }
        public string? State { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }

        private Address() { }

        public Address(string street, string city, string postalCode, string country, string? state = null)
        {
            Street = street ?? throw new ArgumentNullException(nameof(street));
            Suburb = city ?? throw new ArgumentNullException(nameof(city));
            PostCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            State = state;
        }

        public string FullAddress =>
            $"{Street}, {Suburb}{(string.IsNullOrEmpty(State) ? "" : ", " + State)} {PostCode}, {Country}";

    }

}
