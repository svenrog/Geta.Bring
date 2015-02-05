using System;
using System.Collections.Generic;
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
        private const string ViewPath = "~/Views/Shared/Blocks/BringRatesSample.cshtml";

        public override ActionResult Index(BringRatesSampleBlock currentContent)
        {
            return PartialView(ViewPath, new BringRatesSampleBlockView());
        }

        [HttpPost]
        public ActionResult Post(BringRatesSampleBlockView formData)
        {
            Validate(formData);
            if (!ModelState.IsValid)
            {
                return PartialView(ViewPath, formData);
            }

            var model = Search(formData);
            return PartialView(ViewPath, model);
        }

        private void Validate(BringRatesSampleBlockView formData)
        {
            ValidatePackageSize(formData);
        }

        private void ValidatePackageSize(BringRatesSampleBlockView formData)
        {
            var hasWeight = formData.Weight.HasValue;
            var hasDimensions = formData.Width.HasValue && formData.Height.HasValue && formData.Length.HasValue;
            var hasVolume = formData.Volume.HasValue;
            var hasPackageSize = hasWeight || hasDimensions || hasVolume;

            if (!hasPackageSize)
            {
                ModelState.AddModelError("", "Ingen pakkestørrelse gitt. Vennligst oppgi vekt, volum eller dimensjoner.");
            }
        }

        private BringRatesSampleBlockView Search(BringRatesSampleBlockView formData)
        {
            var settings = new ShippingSettings(GetBaseUri());
            var client = new ShippingClient(settings);

            var shipmentLeg = ViewHelper.GetShipmentLeg(formData);
            var packageSize = ViewHelper.GetPackageSize(formData);
            var additionalParameters = ViewHelper.GetAdditionalParameters(formData);

            var query = new EstimateQuery(shipmentLeg, packageSize, additionalParameters);
            var result = client.FindAsync<ShipmentEstimate>(query).Result;

            var estimateGroups = result.Estimates
                .GroupBy(x => x.GuiInformation.MainDisplayCategory)
                .Select(x => new BringRatesSampleBlockView.EstimateGroup(x.Key, x));

            var model = new BringRatesSampleBlockView(estimateGroups);
            return model;
        }

        private Uri GetBaseUri()
        {
            if (Request.Url == null)
            {
                throw new Exception("Request.Url is null.");
            }

            return new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")));
        }

        private static class ViewHelper
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

            public static IQueryParameter[] GetAdditionalParameters(BringRatesSampleBlockView view)
            {
                var parameters = new List<IQueryParameter>();

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
}