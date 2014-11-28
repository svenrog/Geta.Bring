using System;
using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    public class ShippingSettings
    {
        public ShippingSettings(
            Uri clientUri, 
            IEnumerable<IQueryHandler> queryHandlers = null, 
            string publicId = null)
            : this(clientUri, new Uri("https://api.bring.com/shippingguide/products/"), queryHandlers, publicId) { }

        public ShippingSettings(
            Uri clientUri, 
            Uri endpointUri, 
            IEnumerable<IQueryHandler> queryHandlers = null, 
            string publicId = null)
        {
            if (clientUri == null) throw new ArgumentNullException("clientUri");
            if (endpointUri == null) throw new ArgumentNullException("endpointUri");
            PublicId = publicId;
            EndpointUri = endpointUri;
            ClientUri = clientUri;

            var defaultHandlers = CreateDefaultQueryHandlers(this);
            QueryHandlers = defaultHandlers.Concat(queryHandlers ?? Enumerable.Empty<IQueryHandler>());
        }

        public Uri ClientUri { get; private set; }
        public Uri EndpointUri { get; private set; }
        public IEnumerable<IQueryHandler> QueryHandlers { get; private set; }
        public string PublicId { get; private set; }

        private static IEnumerable<IQueryHandler> CreateDefaultQueryHandlers(ShippingSettings settings)
        {
            yield return new ShipmentEstimateQueryHandler(settings);
            yield return new PriceEstimateQueryHandler(settings);
            yield return new DeliveryEstimateQueryHandler(settings);
        }
    }
}