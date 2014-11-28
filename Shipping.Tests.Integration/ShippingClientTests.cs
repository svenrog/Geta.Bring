using System;
using System.Threading.Tasks;
using Geta.Bring.Shipping;
using Geta.Bring.Shipping.Model;
using Geta.Bring.Shipping.Model.QueryParameters;
using Xunit;

namespace Shipping.Tests.Integration
{
    public class ShippingClientTests
    {
        [Fact]
        public async Task it_()
        {
            var settings = new ShippingSettings(new Uri("http://test.localtest.me"));
            var sut = new ShippingClient(settings);

            var query = new EstimateQuery(
                new ShipmentLeg("0484", "5600"),
                PackageSize.InGrams(2500));

            var actual = await sut.FindAsync<ShipmentEstimate>(query);
            /*var actual = await sut.GetEstimatedPrice(query);
            var actual = await sut.GetEstimatedDelivery(query);*/

        }
    }

    
}