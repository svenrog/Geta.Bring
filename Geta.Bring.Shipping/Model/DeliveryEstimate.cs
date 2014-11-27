using System;

namespace Geta.Bring.Shipping.Model
{
    public class DeliveryEstimate : IEstimate
    {
        public DeliveryEstimate(Product product, ExpectedDelivery expectedDelivery)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (expectedDelivery == null) throw new ArgumentNullException("expectedDelivery");
            ExpectedDelivery = expectedDelivery;
            Product = product;
        }

        public Product Product { get; private set; }
        public ExpectedDelivery ExpectedDelivery { get; private set; }
    }
}