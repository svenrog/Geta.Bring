using System;
using System.Threading.Tasks;
using FluentAssertions;
using Geta.Bring.Shipping;
using Geta.Bring.Shipping.Model;
using Geta.Bring.Shipping.Model.QueryParameters;
using Xunit;

namespace Tests.Integration.Shipping
{
    public class ShippingClientTests
    {
        [Fact]
        public async Task it_returns_result()
        {
            var settings = new ShippingSettings(new Uri("http://test.localtest.me"));
            var sut = new ShippingClient(settings);

            var query = new EstimateQuery(
                new ShipmentLeg("0484", "56000"),
                PackageSize.InGrams(2500));

            var actual = await sut.FindAsync<ShipmentEstimate>(query).ConfigureAwait(false);

            actual.Estimates.Should().NotBeEmpty();
        }
    }
}