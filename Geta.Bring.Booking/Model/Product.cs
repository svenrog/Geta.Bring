using System;

namespace Geta.Bring.Booking.Model
{
    public class Product
    {
        public Product(string id, string customerNumber)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (customerNumber == null) throw new ArgumentNullException("customerNumber");
            CustomerNumber = customerNumber;
            Id = id;
        }

        public string Id { get; private set; }
        public string CustomerNumber { get; private set; }
    }
}