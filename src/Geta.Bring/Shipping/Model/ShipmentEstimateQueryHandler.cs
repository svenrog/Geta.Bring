﻿namespace Geta.Bring.Shipping.Model
{
    public class ShipmentEstimateQueryHandler : QueryHandler<ShipmentEstimate>
    {
        public ShipmentEstimateQueryHandler(ShippingSettings settings)
            : base(settings, "all.json")
        { }

        internal override ShipmentEstimate MapProduct(ProductResponse response)
        {
            return new ShipmentEstimate(
                Product.GetByCode(response.ProductId),
                response.GuiInformation,
                response.NetPrice ?? response.Price,
                response.ExpectedDelivery);
        }
    }
}