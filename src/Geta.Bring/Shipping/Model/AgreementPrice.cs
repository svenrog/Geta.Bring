namespace Geta.Bring.Shipping.Model
{
    public class AgreementPrice
    {
        public AgreementPrice(
            string agreementName, 
            int agreementNumber,
            string subAgreementName,
            int subAgreementNumber,
            double price)
        {
            AgreementName = agreementName;
            AgreementNumber = agreementNumber;
            SubAgreementName = subAgreementName;
            SubAgreementNumber = subAgreementNumber;
            Price = price;
        }

        /// <summary>
        /// Name of main agreement
        /// </summary>
        public string AgreementName { get; private set; }

        /// <summary>
        /// Main agreement identifier
        /// </summary>
        public int AgreementNumber { get; private set; }

        /// <summary>
        /// Sub agreement name
        /// </summary>
        public string SubAgreementName { get; private set; }

        /// <summary>
        /// Sub agreement identifier
        /// </summary>
        public int SubAgreementNumber { get; private set; }

        /// <summary>
        /// Agreement price w/o VAT (default NOK)
        /// </summary>
        public double Price { get; private set; }
    }
}