using System;

namespace Geta.Bring.Shipping.Model
{
    public class PriceEstimate : IEstimate
    {
        public PriceEstimate(Product product, Price price)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (price == null) throw new ArgumentNullException("price");
            Price = price;
            Product = product;
        }

        public Product Product { get; private set; }
        public Price Price { get; private set; }
    }
}