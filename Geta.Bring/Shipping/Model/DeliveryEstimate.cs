using System;

namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Estimated delivery information.
    /// </summary>
    public class DeliveryEstimate : IEstimate
    {
        /// <summary>
        /// Initializes new instance of <see cref="DeliveryEstimate"/>
        /// </summary>
        /// <param name="product">Product for which delivery estimated.</param>
        /// <param name="expectedDelivery">Expected delivery information.</param>
        public DeliveryEstimate(Product product, ExpectedDelivery expectedDelivery)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (expectedDelivery == null) throw new ArgumentNullException("expectedDelivery");
            ExpectedDelivery = expectedDelivery;
            Product = product;
        }

        /// <summary>
        /// Product for which delivery estimated <see cref="Product"/>.
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// Expected delivery information <see cref="ExpectedDelivery"/>.
        /// </summary>
        public ExpectedDelivery ExpectedDelivery { get; private set; }
    }
}