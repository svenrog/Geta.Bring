using EPiServer.Commerce.Order;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Catalog.Managers;

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

            var catalogEntryDto = CatalogContext
                .Current
                .GetCatalogEntryDto(
                    lineItem.Code, 
                    new CatalogEntryResponseGroup(
                        CatalogEntryResponseGroup.ResponseGroup.CatalogEntryFull));

            if (catalogEntryDto.CatalogEntry.Count <= 0)
            {
                return 0;
            }

            // Todo: modify for packages
            var variationRows = catalogEntryDto.CatalogEntry[0].GetVariationRows();
            if (variationRows == null || variationRows.Length <= 0)
            {
                return 0;
            }

            return (decimal)variationRows[0].Weight; 
        }
    }
}