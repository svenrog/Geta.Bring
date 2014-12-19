using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Catalog.Managers;
using Mediachase.Commerce.Orders;

namespace Geta.Bring.EPi.Commerce.Extensions
{
    internal static class LineItemExtensions
    {
        public static decimal GetWeight(this LineItem lineItem)
        {
            if (string.IsNullOrEmpty(lineItem.CatalogEntryId))
            {
                return 0;
            }

            var catalogEntryDto = CatalogContext
                .Current
                .GetCatalogEntryDto(
                    lineItem.CatalogEntryId, 
                    new CatalogEntryResponseGroup(
                        CatalogEntryResponseGroup.ResponseGroup.CatalogEntryFull));

            if (catalogEntryDto.CatalogEntry.Count <= 0)
            {
                return 0;
            }

            var variationRows = catalogEntryDto.CatalogEntry[0].GetVariationRows();
            if (variationRows == null || variationRows.Length <= 0)
            {
                return 0;
            }

            return (decimal)variationRows[0].Weight; 
        }
    }
}