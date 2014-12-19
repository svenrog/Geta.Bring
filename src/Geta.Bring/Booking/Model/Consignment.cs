using System;
using System.Collections.Generic;

namespace Geta.Bring.Booking.Model
{
    /// <summary>
    /// Consignment information.
    /// </summary>
    public class Consignment
    {
        /// <summary>
        /// Initializes new instance of <see cref="Consignment"/>.
        /// </summary>
        /// <param name="correlationId">Correlation ID.</param>
        /// <param name="shippingDateTime">Shipping date and time to Bring.</param>
        /// <param name="parties">Parties information. For more see: <see cref="Parties"/>.</param>
        /// <param name="product">Product information. For more see: <see cref="Product"/>.</param>
        /// <param name="packages">List of package information included in consignment. For more see <see cref="Package"/>.</param>
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

        /// <summary>
        /// Correlation ID.
        /// </summary>
        public string CorrelationId { get; private set; }

        /// <summary>
        /// Shipping date and time to Bring.
        /// </summary>
        public DateTime ShippingDateTime { get; private set; }

        /// <summary>
        /// Parties information. For more see: <see cref="Parties"/>.
        /// </summary>
        public Parties Parties { get; private set; }

        /// <summary>
        /// Product information. For more see: <see cref="Product"/>.
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// List of package information included in consignment. For more see <see cref="Package"/>.
        /// </summary>
        public IEnumerable<Package> Packages { get; private set; }
    }
}