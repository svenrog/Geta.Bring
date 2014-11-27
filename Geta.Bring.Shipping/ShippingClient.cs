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

        public async Task<T> Find<T>(EstimateQuery query)
            where T : IEstimate
        {
            throw new NotImplementedException();
        }
    }
}