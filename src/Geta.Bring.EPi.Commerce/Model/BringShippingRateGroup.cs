using System;
using System.Collections.Generic;

namespace Geta.Bring.EPi.Commerce.Model
{
    public class BringShippingRateGroup
    {
        public BringShippingRateGroup(string name, IEnumerable<BringShippingRate> shippingRates)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (shippingRates == null) throw new ArgumentNullException("shippingRates");
            ShippingRates = shippingRates;
            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<BringShippingRate> ShippingRates { get; private set; }
    }
}