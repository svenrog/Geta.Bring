using System;

namespace Geta.Bring.Shipping.Model
{
    public class ShipmentEstimate : IEstimate
    {
        public ShipmentEstimate(
            Product product, 
            GuiInformation guiInformation, 
            Price price, 
            ExpectedDelivery expectedDelivery)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (guiInformation == null) throw new ArgumentNullException("guiInformation");
            if (price == null) throw new ArgumentNullException("price");
            if (expectedDelivery == null) throw new ArgumentNullException("expectedDelivery");
            ExpectedDelivery = expectedDelivery;
            Price = price;
            GuiInformation = guiInformation;
            Product = product;
        }

        public Product Product { get; private set; }
        public GuiInformation GuiInformation { get; private set; }
        public Price Price { get; private set; }
        public ExpectedDelivery ExpectedDelivery { get; private set; }
    }
}