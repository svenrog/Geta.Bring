using System;
using Newtonsoft.Json;

namespace Geta.Bring.Shipping.Model
{
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

        [JsonProperty("@currencyIdentificationCode")]
        public string CurrencyIdentificationCode { get; private set; }

        public Price PackagePriceWithoutAdditionalServices { get; private set; }
        public Price PackagePriceWithAdditionalServices { get; private set; }
    }

    public class Price
    {
        public Price(
            double amountWithoutVat, 
            double vat, 
            double amountWithVat)
        {
            AmountWithVAT = amountWithVat;
            VAT = vat;
            AmountWithoutVAT = amountWithoutVat;
        }

        public double AmountWithoutVAT { get; private set; }

        public double VAT { get; private set; }

        public double AmountWithVAT { get; private set; }
    }
}