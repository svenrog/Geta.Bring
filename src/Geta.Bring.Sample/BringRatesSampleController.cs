using System;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Geta.Bring.Shipping;
using Geta.Bring.Shipping.Model;
using Geta.Bring.Shipping.Model.QueryParameters;

namespace Geta.Bring.Sample
{
    public class BringRatesSampleController : BlockController<BringRatesSampleBlock>
    {
        public override ActionResult Index(BringRatesSampleBlock currentContent)
        {
            // TODO: get URL from HTTP context
            var settings = new ShippingSettings(new Uri("http://test.localtest.me"));
            IShippingClient client = new ShippingClient(settings);

            var query = new EstimateQuery(new ShipmentLeg("0484", "5600"), PackageSize.InGrams(2500));
            var result = client.FindAsync<ShipmentEstimate>(query).Result;

            var estimateGroups = result.Estimates
                .GroupBy(x => x.GuiInformation.MainDisplayCategory)
                .Select(x => new BringRatesSampleBlockView.EstimateGroup(x.Key, x));

            var model = new BringRatesSampleBlockView(estimateGroups);
            return PartialView("~/Views/Shared/Blocks/BringRatesSample.cshtml", model);
        }
    }
}