using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model
{
    public interface IQueryParameter
    {
        NameValueCollection Items { get; }
    }
}