using System;
using System.Collections.Generic;
using Geta.Bring.Shipping.Infrastructure;
using Newtonsoft.Json;

namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Price information.
    /// </summary>
    public class PackagePrice
    {
        public PackagePrice(
            string currencyIdentificationCode,
            Price packagePriceWithoutAdditionalServices, 
            Price packagePriceWithAdditionalServices,
            CargoAgreementPrices cargoAgreementPrices = null)
        {
            if (currencyIdentificationCode == null) throw new ArgumentNullException("currencyIdentificationCode");
            if (packagePriceWithoutAdditionalServices == null)
                throw new ArgumentNullException("packagePriceWithoutAdditionalServices");
            if (packagePriceWithAdditionalServices == null)
                throw new ArgumentNullException("packagePriceWithAdditionalServices");
            PackagePriceWithAdditionalServices = packagePriceWithAdditionalServices;
            PackagePriceWithoutAdditionalServices = packagePriceWithoutAdditionalServices;
            CurrencyIdentificationCode = currencyIdentificationCode;
            CargoAgreementPrices = cargoAgreementPrices;
        }

        [JsonConstructor]
        public PackagePrice(
            string currencyIdentificationCode,
            Price packagePriceWithoutAdditionalServices, 
            Price packagePriceWithAdditionalServices,
            CargoAgreementPrices cargoAgreementPrices) : 
                this(currencyIdentificationCode, packagePriceWithoutAdditionalServices, packagePriceWithAdditionalServices)
        {
            CargoAgreementPrices = cargoAgreementPrices;
        }

        /// <summary>
        /// Currency code.
        /// </summary>
        [JsonProperty("@currencyIdentificationCode")]
        public string CurrencyIdentificationCode { get; private set; }

        /// <summary>
        /// Price without additional services.
        /// </summary>
        public Price PackagePriceWithoutAdditionalServices { get; private set; }

        /// <summary>
        /// Price with additional services.
        /// </summary>
        public Price PackagePriceWithAdditionalServices { get; private set; }

        /// <summary>
        /// Special cargo agreement prices.
        /// </summary>
        public CargoAgreementPrices CargoAgreementPrices { get; private set; }
    }
}