using System;

namespace Geta.Bring.Booking.Model
{
    public class Party
    {
        public Party(
            string name, 
            string addressLine, 
            string addressLine2, 
            string postalCode, 
            string city, 
            string countryCode, 
            string reference, 
            string additionalAddressInfo, 
            Contact contact)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (addressLine == null) throw new ArgumentNullException("addressLine");
            if (postalCode == null) throw new ArgumentNullException("postalCode");
            if (city == null) throw new ArgumentNullException("city");
            if (countryCode == null) throw new ArgumentNullException("countryCode");
            if (reference == null) throw new ArgumentNullException("reference");
            if (contact == null) throw new ArgumentNullException("contact");
            Contact = contact;
            AdditionalAddressInfo = additionalAddressInfo;
            Reference = reference;
            CountryCode = countryCode;
            City = city;
            PostalCode = postalCode;
            AddressLine2 = addressLine2;
            AddressLine = addressLine;
            Name = name;
        }

        public string Name { get; private set; }
        public string AddressLine { get; private set; }
        public string AddressLine2 { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string CountryCode { get; private set; }
        public string Reference { get; private set; }
        public string AdditionalAddressInfo { get; private set; }
        public Contact Contact { get; private set; }
    }
}