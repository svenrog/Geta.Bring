using System;
using System.Collections.Generic;
using Geta.Bring.Shipping.Infrastructure;
using Newtonsoft.Json;

namespace Geta.Bring.Shipping.Model
{
    internal class ShippingResponse
    {
        public ShippingResponse(IEnumerable<ProductResponse> product)
        {
            if (product == null) throw new ArgumentNullException("product");
            Product = product;
        }

        [JsonConverter(typeof(ObjectToArrayConverter<ProductResponse>))]
        public IEnumerable<ProductResponse> Product { get; private set; }
    }
}