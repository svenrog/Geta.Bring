using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Infrastructure;
using Newtonsoft.Json;

namespace Geta.Bring.Shipping.Model
{
    internal class ShippingResponse
    {
        public ShippingResponse(IEnumerable<ProductResponse> product, TraceMessages traceMessages)
        {
            Product = product;
            TraceMessages = traceMessages ?? new TraceMessages(Enumerable.Empty<string>());
        }

        [JsonConverter(typeof(ObjectToArrayConverter<ProductResponse>))]
        public IEnumerable<ProductResponse> Product { get; private set; }

        public TraceMessages TraceMessages { get; private set; }
    }
}