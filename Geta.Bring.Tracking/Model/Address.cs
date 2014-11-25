using System;

namespace Geta.Bring.Tracking.Model
{
    public class Address
    {
        public Address(
            string addressLine1, 
            string addressLine2, 
            string postalCode, 
            string city,
            string countryCode, 
            string country)
        {
            if (addressLine1 == null) throw new ArgumentNullException("addressLine1");
            if (addressLine2 == null) throw new ArgumentNullException("addressLine2");
            if (postalCode == null) throw new ArgumentNullException("postalCode");
            if (city == null) throw new ArgumentNullException("city");
            if (countryCode == null) throw new ArgumentNullException("countryCode");
            if (country == null) throw new ArgumentNullException("country");
            Country = country;
            CountryCode = countryCode;
            City = city;
            PostalCode = postalCode;
            AddressLine2 = addressLine2;
            AddressLine1 = addressLine1;
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string CountryCode { get; private set; }
        public string Country { get; private set; }
    }
}