using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Domain.ValueObjects
{
    public class Address
    {
        public string Title { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; } 
        public string FullAddress { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string title, string city, string district, string fullAddress, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City cannot be empty.", nameof(city));
            }

            if (string.IsNullOrWhiteSpace(district))
            {
                throw new ArgumentException("District cannot be empty.", nameof(district));
            }

            if (string.IsNullOrWhiteSpace(fullAddress))
            {
                throw new ArgumentException("Full adress cannot be empty.", nameof(fullAddress));
            }

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("Full adress cannot be empty.", nameof(zipCode));
            }

            Title = title;
            City = city;
            District = district;
            FullAddress = fullAddress;
            ZipCode = zipCode;

        }

        private Address() { }

    }
}
