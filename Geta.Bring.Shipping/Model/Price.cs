namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Price.
    /// </summary>
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

        /// <summary>
        /// Price without VAT in NOK.
        /// </summary>
        public double AmountWithoutVAT { get; private set; }

        /// <summary>
        /// VAT in NOK.
        /// </summary>
        public double VAT { get; private set; }

        /// <summary>
        /// Price with VAT in NOK.
        /// </summary>
        public double AmountWithVAT { get; private set; }
    }
}