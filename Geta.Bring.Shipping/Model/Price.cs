namespace Geta.Bring.Shipping.Model
{
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