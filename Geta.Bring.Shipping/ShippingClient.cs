using System;
using System.Threading.Tasks;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    public class ShippingClient
    {
        public ShippingSettings Settings { get; private set; }

        public ShippingClient(ShippingSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            Settings = settings;
        }

        public async Task<T> FindAsync<T>(EstimateQuery query)
            where T : IEstimate
        {
            foreach (var handler in Settings.QueryHandlers)
            {
                if (handler.CanHandle(typeof(T)))
                {
                    return (T)await handler.FindEstimateAsync(query).ConfigureAwait(false);
                }
            }

            throw new Exception(string.Format("No matching query handler found for estimate type {0}", typeof(T).Name));
        }
    }
}