using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class ShippedFromPostOffice : IQueryParameter
    {
        public ShippedFromPostOffice(bool shippedFromPostOffice)
        {
            Items = new NameValueCollection
            {
                {"postingAtPostoffice", shippedFromPostOffice.ToString().ToLowerInvariant()}
            };
        }
        public NameValueCollection Items { get; private set; }
    }
}