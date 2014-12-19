using System;
using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    /// <summary>
    /// Settings for <see cref="ShippingClient" /> 
    /// </summary>
    public class ShippingSettings
    {
        /// <summary>
        /// Initializes new instance of <see cref="ShippingSettings"/> with default Bring Shipping Guide API endpoint: https://api.bring.com/shippingguide/products/
        /// </summary>
        /// <param name="clientUri">The URI of client Web site.</param>
        /// <param name="queryHandlers">Additional <see cref="IQueryHandler"/>s. Allows to register additional query handlers for new API endpoints in future.</param>
        /// <param name="publicId">Shipping Guide Public ID. Public ID is the last part (after the last dash) of your identification string. More info: http://developer.bring.com/api/shippingguideapi.html </param>
        public ShippingSettings(
            Uri clientUri, 
            IEnumerable<IQueryHandler> queryHandlers = null, 
            string publicId = null)
            : this(clientUri, new Uri("https://api.bring.com/shippingguide/products/"), queryHandlers, publicId) { }

        /// <summary>
        /// Initializes new instance of <see cref="ShippingSettings"/>
        /// </summary>
        /// <param name="clientUri">The URI of client Web site.</param>
        /// <param name="endpointUri">The URI of Bring Shipping Guide API endpoint.</param>
        /// <param name="queryHandlers">Additional <see cref="IQueryHandler"/>s. Allows to register additional query handlers for new API endpoints in future.</param>
        /// <param name="publicId">Shipping Guide Public ID. Public ID is the last part (after the last dash) of your identification string. More info: http://developer.bring.com/api/shippingguideapi.html </param>
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