using System;
using System.Collections.Generic;

namespace Geta.Bring.Booking.Model
{
    public class Consignment
    {
        public Consignment(
            string correlationId, 
            DateTime shippingDateTime, 
            Parties parties, 
            Product product, 
            IEnumerable<Package> packages)
        {
            if (correlationId == null) throw new ArgumentNullException("correlationId");
            if (parties == null) throw new ArgumentNullException("parties");
            if (product == null) throw new ArgumentNullException("product");
            if (packages == null) throw new ArgumentNullException("packages");
            Packages = packages;
            Product = product;
            ShippingDateTime = shippingDateTime;
            Parties = parties;
            CorrelationId = correlationId;
        }

        public string CorrelationId { get; private set; }
        public DateTime ShippingDateTime { get; private set; }
        public Parties Parties { get; private set; }
        public Product Product { get; private set; }
        public IEnumerable<Package> Packages { get; private set; }
    }
}