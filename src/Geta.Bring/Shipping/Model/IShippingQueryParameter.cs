using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model
{
    public interface IShippingQueryParameter
    {
        NameValueCollection Items { get; }
    }
}