using System;

namespace Geta.Bring.Shipping.Model
{
    public class ShipmentEstimate : IEstimate
    {
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

        public Product Product { get; private set; }
        public GuiInformation GuiInformation { get; private set; }
        public PackagePrice PackagePrice { get; private set; }
        public ExpectedDelivery ExpectedDelivery { get; private set; }
    }
}