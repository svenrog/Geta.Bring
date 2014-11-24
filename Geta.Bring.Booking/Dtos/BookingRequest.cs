using System;
using System.Collections.Generic;

namespace Geta.Bring.Booking.Dtos
{
    internal class BookingRequest
    {
        public bool TestIndicator { get; set; }
        public int SchemaVersion { get; set; }
        public IEnumerable<Consignment> Consignments { get; set; }

        public class Consignment
        {
            public string CorrelationId { get; set; }
            public DateTime ShippingDateTime { get; set; }
            public Parties Parties { get; set; }
            public Product Product { get; set; }
            public IEnumerable<Package> Packages { get; set; }
        }
        
        public class Parties
        {
            public Party Sender { get; set; }
            public Party Recipient { get; set; }
        }

        public class Party
        {
            public string Name { get; set; }
            public string AddressLine { get; set; }
            public string AddressLine2 { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string CountryCode { get; set; }
            public string Reference { get; set; }
            public string AdditionalAddressInfo { get; set; }
            public Contact Contact { get; set; }
        }

        public class Contact
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class Product
        {
            public string Id { get; set; }
            public string CustomerNumber { get; set; }
        }

        public class Package
        {
            public string CorrelationId { get; set; }
            public double WeightInKg { get; set; }
            public string GoodsDescription { get; set; }
            public Dimensions Dimensions { get; set; }
        }

        public class Dimensions
        {
            public int HeightInCm { get; set; }
            public int WidthInCm { get; set; }
            public int LengthInCm { get; set; }
        }
    }
}