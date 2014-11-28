using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class ShipmentLeg : IQueryParameter
    {
        public ShipmentLeg(string postalCodeFrom, string postalCodeTo)
        {
            Items = new NameValueCollection
            {
                {"from", postalCodeFrom}, 
                {"to", postalCodeTo}
            };
        }

        public ShipmentLeg(
            string postalCodeFrom, 
            string postalCodeTo,
            string countryCodeFrom,
            string countryCodeTo)
        {
            Items = new NameValueCollection
            {
                {"from", postalCodeFrom}, 
                {"to", postalCodeTo},
                {"fromCountry", countryCodeFrom}, 
                {"toCountry", countryCodeTo}
            }; 
        }

        public NameValueCollection Items { get; private set; }
    }
}