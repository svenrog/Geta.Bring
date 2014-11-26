using System;

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
    }
}