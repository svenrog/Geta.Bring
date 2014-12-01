using System;
using System.Linq;
using System.Threading.Tasks;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    public class ShippingClient : Geta.Bring.Shipping.IShippingClient
    {
        public ShippingSettings Settings { get; private set; }

        public ShippingClient(ShippingSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            Settings = settings;
        }

        public async Task<EstimateResult<T>> FindAsync<T>(EstimateQuery query)
            where T : IEstimate
        {
            foreach (var handler in Settings.QueryHandlers)
            {
                if (handler.CanHandle(typeof(T)))
                {
                    var estimate = await handler.FindEstimatesAsync(query).ConfigureAwait(false);
                    return new EstimateResult<T>(estimate.Estimates.Cast<T>());
                }
            }

            throw new Exception(string.Format("No matching query handler found for estimate type {0}", typeof(T).Name));
        }
    }
}