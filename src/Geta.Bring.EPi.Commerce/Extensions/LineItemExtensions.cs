using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Order;

namespace Geta.Bring.EPi.Commerce.Extensions
{
    internal static class LineItemExtensions
    {
        public static decimal GetWeight(this ILineItem lineItem)
        {
            if (string.IsNullOrEmpty(lineItem.Code))
            {
                return 0;
            }

            var entry = lineItem.GetEntryContent();

            if (entry == null)
            {
                return 0;
            }

            decimal weight = 0;
            var package = entry as PackageContent;
            var bundle = entry as BundleContent;

            if (package != null)
            {
                weight = package.CalculateWeight();
            }
            else if (bundle != null)
            {
                weight = bundle.CalculateWeight();
            }

            if (weight == 0)
            {
                var stockPlacementEntry = entry as IStockPlacement;

                if (stockPlacementEntry != null)
                {
                    weight = (decimal)stockPlacementEntry.Weight;
                }
            }

            return weight;
        }
    }
}