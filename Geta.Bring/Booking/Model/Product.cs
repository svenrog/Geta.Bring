using System;

namespace Geta.Bring.Booking.Model
{
    /// <summary>
    /// Bring Product information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes new instance of <see cref="Product"/>.
        /// </summary>
        /// <param name="id">Bring Product code from: http://developer.bring.com/additionalresources/productlist.html?from=shipping .</param>
        /// <param name="customerNumber">Customer number for Bring Product.</param>
        public Product(string id, string customerNumber)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (customerNumber == null) throw new ArgumentNullException("customerNumber");
            CustomerNumber = customerNumber;
            Id = id;
        }

        /// <summary>
        /// Bring Product code from: http://developer.bring.com/additionalresources/productlist.html?from=shipping .
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Customer number for Bring Product.
        /// </summary>
        public string CustomerNumber { get; private set; }
    }
}