using System;

namespace Geta.Bring.Shipping.Model
{
    public class PriceEstimate : IEstimate
    {
        public PriceEstimate(Product product, PackagePrice packagePrice)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (packagePrice == null) throw new ArgumentNullException("packagePrice");
            PackagePrice = packagePrice;
            Product = product;
        }

        public Product Product { get; private set; }
        public PackagePrice PackagePrice { get; private set; }
    }
}