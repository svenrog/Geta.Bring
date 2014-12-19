using System;

namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Estimated shipment information.
    /// </summary>
    public class ShipmentEstimate : IEstimate
    {
        /// <summary>
        /// Initializes new instance of <see cref="ShipmentEstimate"/>.
        /// </summary>
        /// <param name="product">Product for which shipment estimated.</param>
        /// <param name="guiInformation">GUI information.</param>
        /// <param name="packagePrice">Price information.</param>
        /// <param name="expectedDelivery">Expected delivery information.</param>
        public ShipmentEstimate(
            Product product, 
            GuiInformation guiInformation, 
            PackagePrice packagePrice, 
            ExpectedDelivery expectedDelivery)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (guiInformation == null) throw new ArgumentNullException("guiInformation");
            if (packagePrice == null) throw new ArgumentNullException("packagePrice");
            if (expectedDelivery == null) throw new ArgumentNullException("expectedDelivery");
            ExpectedDelivery = expectedDelivery;
            PackagePrice = packagePrice;
            GuiInformation = guiInformation;
            Product = product;
        }

        /// <summary>
        /// Product for which shipment estimated. 
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// GUI information <see cref="GuiInformation"/>.
        /// </summary>
        public GuiInformation GuiInformation { get; private set; }

        /// <summary>
        /// Price information <see cref="PackagePrice"/>.
        /// </summary>
        public PackagePrice PackagePrice { get; private set; }

        /// <summary>
        /// Expected delivery information <see cref="ExpectedDelivery"/>.
        /// </summary>
        public ExpectedDelivery ExpectedDelivery { get; private set; }
    }
}