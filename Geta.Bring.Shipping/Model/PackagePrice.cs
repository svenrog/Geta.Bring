using System;
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
            Price packagePriceWithAdditionalServices)
        {
            if (currencyIdentificationCode == null) throw new ArgumentNullException("currencyIdentificationCode");
            if (packagePriceWithoutAdditionalServices == null)
                throw new ArgumentNullException("packagePriceWithoutAdditionalServices");
            if (packagePriceWithAdditionalServices == null)
                throw new ArgumentNullException("packagePriceWithAdditionalServices");
            PackagePriceWithAdditionalServices = packagePriceWithAdditionalServices;
            PackagePriceWithoutAdditionalServices = packagePriceWithoutAdditionalServices;
            CurrencyIdentificationCode = currencyIdentificationCode;
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
    }
}