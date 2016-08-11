using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Model;
using Geta.Bring.Shipping.Model.QueryParameters;

namespace Geta.Bring.Sample
{
    public static class ParameterMapper
    {
        public static ShipmentLeg GetShipmentLeg(BringRatesSampleBlockView view)
        {
            return new ShipmentLeg(
                view.PostalCodeFrom,
                view.PostalCodeTo,
                view.CountryFrom,
                view.CountryTo);
        }

        public static PackageSize GetPackageSize(BringRatesSampleBlockView view)
        {
            return GetPackageSizes(view).First();
        }

        public static IShippingQueryParameter[] GetAdditionalParameters(BringRatesSampleBlockView view)
        {
            var parameters = new List<IShippingQueryParameter>();

            var additionalPackageSizes = GetPackageSizes(view).Skip(1);
            parameters.AddRange(additionalPackageSizes);
            parameters.AddRange(GetShippingDateAndTime(view));
            parameters.AddRange(GetEdi(view));
            parameters.AddRange(GetShippedFromPostOffice(view));
            parameters.AddRange(GetProducts(view));
            parameters.AddRange(GetAdditionalServices(view));

            return parameters.ToArray();
        }

        private static IEnumerable<AdditionalServices> GetAdditionalServices(BringRatesSampleBlockView view)
        {
            var additionalServices = view.AdditionalServices.Select(AdditionalService.GetByCode).ToList();

            return additionalServices.Count != 0
                ? new[] { new AdditionalServices(additionalServices.ToArray()) }
                : Enumerable.Empty<AdditionalServices>();
        }

        private static IEnumerable<Products> GetProducts(BringRatesSampleBlockView view)
        {
            var products = view.Products.Select(Product.GetByCode).ToList();

            return products.Count != 0
                ? new[] { new Products(products.ToArray()) }
                : Enumerable.Empty<Products>();
        }

        private static IEnumerable<ShippedFromPostOffice> GetShippedFromPostOffice(BringRatesSampleBlockView view)
        {
            yield return new ShippedFromPostOffice(view.ShippedFromPostOffice);
        }

        private static IEnumerable<Edi> GetEdi(BringRatesSampleBlockView view)
        {
            yield return new Edi(view.Edi);
        }

        private static IEnumerable<ShippingDateAndTime> GetShippingDateAndTime(BringRatesSampleBlockView view)
        {
            if (view.ShippingDateAndTime.HasValue)
            {
                yield return new ShippingDateAndTime(view.ShippingDateAndTime.Value);
            }
        }

        private static IEnumerable<PackageSize> GetPackageSizes(BringRatesSampleBlockView view)
        {
            if (view.Weight.HasValue)
            {
                yield return PackageSize.InGrams(view.Weight.Value);
            }

            if (view.Volume.HasValue)
            {
                yield return PackageSize.InVolume(view.Volume.Value);
            }

            if (view.Length.HasValue && view.Width.HasValue && view.Height.HasValue)
            {
                yield return PackageSize.InDimensions(view.Length.Value, view.Width.Value, view.Height.Value);
            }
        }
    }
}