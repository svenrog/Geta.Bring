namespace Geta.Bring.Shipping.Model
{
    public class DeliveryEstimateQueryHandler : QueryHandler<DeliveryEstimate>
    {
        public DeliveryEstimateQueryHandler(ShippingSettings settings)
            : base(settings, "expectedDelivery.json")
        {
        }

        internal override DeliveryEstimate MapProduct(ProductResponse response)
        {
            return new DeliveryEstimate(
                Product.GetByCode(response.ProductId),
                response.ExpectedDelivery);
        }
    }
}