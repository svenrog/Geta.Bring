using System;

namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Estimated price information.
    /// </summary>
    public class PriceEstimate : IEstimate
    {
        /// <summary>
        /// Initializes new instance of <see cref="PriceEstimate"/>.
        /// </summary>
        /// <param name="product">Product for which price estimated.</param>
        /// <param name="packagePrice">Price information.</param>
        public PriceEstimate(Product product, PackagePrice packagePrice)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (packagePrice == null) throw new ArgumentNullException("packagePrice");
            PackagePrice = packagePrice;
            Product = product;
        }

        /// <summary>
        /// Product for which price estimated <see cref="Product"/>.
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// Price information <see cref="PackagePrice"/>.
        /// </summary>
        public PackagePrice PackagePrice { get; private set; }
    }
}