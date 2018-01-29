using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.ServiceLocation;

namespace Geta.Bring.EPi.Commerce.Extensions
{
    internal static class BundleContentExtensions
    {
        private static Injected<IRelationRepository> _injectedRelationRepository;
        private static Injected<IContentLoader> _injectedContentLoader;

        public static decimal CalculateWeight(this BundleContent bundle)
        {
            var entryRelations = _injectedRelationRepository.Service.GetChildren<BundleEntry>(bundle.ContentLink);
            var contentLoader = _injectedContentLoader.Service;

            decimal weight = 0;

            foreach (var entryRelation in entryRelations)
            {
                if (contentLoader.TryGet(entryRelation.Child, out EntryContentBase entry))
                {
                    var stockPlacementEntry = entry as IStockPlacement;

                    if (stockPlacementEntry != null)
                    {
                        weight += (decimal)stockPlacementEntry.Weight * entryRelation.Quantity.GetValueOrDefault(1);
                    }
                }
            }

            return weight;
        }
    }
}