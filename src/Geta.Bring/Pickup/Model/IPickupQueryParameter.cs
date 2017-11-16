using System.Collections.Specialized;

namespace Geta.Bring.Pickup.Model
{
    public interface IPickupQueryParameter
    {
        NameValueCollection Items { get; }
    }
}