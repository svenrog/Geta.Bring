using System.Collections.Generic;

namespace Geta.Bring.Shipping
{
    public class ShippingSettings
    {
        public IEnumerable<IQueryHandler> QueryHandlers { get; set; }
    }
}