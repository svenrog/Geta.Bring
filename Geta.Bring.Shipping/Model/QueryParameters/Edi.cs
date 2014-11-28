using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class Edi : IQueryParameter
    {
        public Edi(bool usesEdi)
        {
            Items = new NameValueCollection
            {
                {"edi", usesEdi.ToString().ToLowerInvariant()}
            };
        }
        public NameValueCollection Items { get; private set; }
    }
}