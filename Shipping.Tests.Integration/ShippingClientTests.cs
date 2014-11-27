using System.Threading.Tasks;
using Geta.Bring.Shipping;
using Geta.Bring.Shipping.Model;
using Xunit;

namespace Shipping.Tests.Integration
{
    public class ShippingClientTests
    {
        [Fact]
        public async Task it_()
        {
            var settings = new ShippingSettings();
            var sut = new ShippingClient(settings);

            var query = new EstimateQuery();
            var actual = await sut.Find<ShipmentEstimate>(query);
            /*var actual = await sut.GetEstimatedPrice(query);
            var actual = await sut.GetEstimatedDelivery(query);*/
        }

        
    }

    
}