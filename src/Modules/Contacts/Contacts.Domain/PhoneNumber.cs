using PhoneBook.Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Contacts.Domain
{
    public record PhoneNumber : ValueObject
    {
        public string Number { get; private set; }
        public string? CountryCode { get; private set; }
        public string? Extension { get; private set; }

        private PhoneNumber() { }

        public PhoneNumber(string number, string? countryCode = null, string? extension = null)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty", nameof(number));

            var cleaned = Regex.Replace(number, @"[^\d]", "");
            if (cleaned.Length < 10)
                throw new ArgumentException("Phone number must have at least 10 digits", nameof(number));

            Number = number;
            CountryCode = countryCode;
            Extension = extension;
        }

        public string FormattedNumber =>
            string.IsNullOrEmpty(CountryCode) ? Number : $"+{CountryCode} {Number}";
    }

}
