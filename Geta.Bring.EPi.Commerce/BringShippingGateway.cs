using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using Geta.Bring.EPi.Commerce.Extensions;
using Geta.Bring.EPi.Commerce.Model;
using Geta.Bring.Shipping.Model;
using Geta.Bring.Shipping.Model.QueryParameters;
using Mediachase.Commerce;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Dto;
using Mediachase.Commerce.Orders.Managers;
using Geta.Bring.Shipping;

namespace Geta.Bring.EPi.Commerce
{
    public class BringShippingGateway : IShippingGateway
    {
        private readonly IShippingClient _shippingClient;

        public BringShippingGateway()
        {
            _shippingClient = ServiceLocator.Current.GetInstance<IShippingClient>();
        }

        public ShippingRate GetRate(Guid methodId, Shipment shipment, ref string message)
        {
            if (shipment == null)
            {
                return null;
            }

            var shippingMethod = ShippingManager.GetShippingMethod(methodId);
            if (shippingMethod == null || shippingMethod.ShippingMethod.Count <= 0)
            {
                message = string.Format(ErrorMessages.ShippingMethodCouldNotBeLoaded, methodId);
                return null;
            }

            var shipmentLineItems = Shipment.GetShipmentLineItems(shipment);
            if (shipmentLineItems.Count == 0)
            {
                message = ErrorMessages.ShipmentContainsNoLineItems;
                return null;
            }

            if (shipment.Parent == null || shipment.Parent.Parent == null)
            {
                message = ErrorMessages.OrderFormOrOrderGroupNotFound;
                return null;
            }

            var orderAddress =
                shipment.Parent
                    .Parent
                    .OrderAddresses
                    .FirstOrDefault(address => address.Name == shipment.ShippingAddressId);
            if (orderAddress == null)
            {
                message = ErrorMessages.ShipmentAddressNotFound;
                return null;
            }

            var query = BuildQuery(orderAddress, shippingMethod, shipment, shipmentLineItems);
            var result = _shippingClient.FindAsync<ShipmentEstimate>(query).Result;

            return CreateShippingRate(methodId, shippingMethod, result);
        }

        private static EstimateQuery BuildQuery(
            OrderAddress orderAddress,
            ShippingMethodDto shippingMethod,
            Shipment shipment, 
            IEnumerable<LineItem> shipmentLineItems)
        {
            var shipmentLeg = CreateShipmentLeg(orderAddress, shippingMethod);
            var packageSize = CreatePackageSize(shipment, shipmentLineItems);
            return new EstimateQuery(
                shipmentLeg,
                packageSize); // TODO: Add more parameters
        }

        private static PackageSize CreatePackageSize(Shipment shipment, IEnumerable<LineItem> shipmentLineItems)
        {
            var weight = shipmentLineItems
                .Select(item => item.GetWeight()*Shipment.GetLineItemQuantity(shipment, item.Id))
                .Sum() * 1000; // KG to grams
            return PackageSize.InGrams((int)weight);
        }

        private static ShipmentLeg CreateShipmentLeg(OrderAddress orderAddress, ShippingMethodDto shippingMethod)
        {
            var postalCodeFrom = shippingMethod.GetShippingMethodParameterValue(ParameterNames.PostalCodeFrom, null)
                                 ?? shippingMethod.GetShippingOptionParameterValue(ParameterNames.PostalCodeFrom);
            var countryCodeFrom = shippingMethod
                .GetShippingOptionParameterValue(ParameterNames.CountryFrom, "NOR")
                .ToIso2CountryCode();
            var countryCodeTo = orderAddress.CountryCode.ToIso2CountryCode();
            return new ShipmentLeg(postalCodeFrom, orderAddress.PostalCode, countryCodeFrom, countryCodeTo);
        }

        private ShippingRate CreateShippingRate(
            Guid methodId, 
            ShippingMethodDto shippingMethod, 
            EstimateResult<ShipmentEstimate> result)
        {
            var estimate = result.Estimates.First();
            var shippingMethodRow = shippingMethod.ShippingMethod[0];
            var amount = new Money(
                shippingMethodRow.BasePrice +
               (decimal) estimate.PackagePrice.PackagePriceWithAdditionalServices.AmountWithVAT,
                new Currency(estimate.PackagePrice.CurrencyIdentificationCode));
            
            return new BringShippingRate(
                methodId,
                estimate.GuiInformation.DisplayName,
                estimate.GuiInformation.MainDisplayCategory,
                estimate.GuiInformation.SubDisplayCategory,
                estimate.GuiInformation.DescriptionText,
                estimate.GuiInformation.HelpText,
                estimate.GuiInformation.Tip,
                amount);
        }

        internal static class ParameterNames
        {
            public const string PostalCodeFrom = "PostalCodeFrom";
            public const string CountryFrom = "CountryFrom";
        }

        internal static class ErrorMessages
        {
            public const string ShipmentAddressNotFound = 
                "The shipment address not found in order group.";

            public const string OrderFormOrOrderGroupNotFound =
                "The order form or order group not found for shipment.";

            public const string ShippingMethodCouldNotBeLoaded = 
                "The shipping method could not be loaded by '{0}' id.";

            public const string ShipmentContainsNoLineItems =
                "The shipment doesn't contain any line items.";
        }
    }
}