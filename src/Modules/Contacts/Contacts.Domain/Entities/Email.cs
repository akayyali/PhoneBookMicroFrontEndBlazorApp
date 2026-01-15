using PhoneBook.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entities
{
    public record Email : ValueObject
    {
        public string Address { get; private set; }

        private Email() { }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email address cannot be empty", nameof(address));
            if (!IsValidEmail(address))
                throw new ArgumentException("Invalid email format", nameof(address));

            Address = address.ToLowerInvariant();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }

        public override string ToString() => Address;
    }

}
