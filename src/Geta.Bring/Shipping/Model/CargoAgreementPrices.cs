using System;

namespace Geta.Bring.Shipping.Model
{
    public class CargoAgreementPrices
    {
        public CargoAgreementPrices(AgreementPrice cargoAgreementPrice)
        {
            if (cargoAgreementPrice == null) throw new ArgumentNullException("cargoAgreementPrice");
            CargoAgreementPrice = cargoAgreementPrice;
        }

        /// <summary>
        /// Cargo agreement
        /// </summary>
        public AgreementPrice CargoAgreementPrice { get; private set; }
    }
}