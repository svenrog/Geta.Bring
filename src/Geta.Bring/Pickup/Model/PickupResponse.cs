using System.Collections.Generic;
using System.Linq;
using Geta.Bring.Shipping.Infrastructure;
using Newtonsoft.Json;

namespace Geta.Bring.Pickup.Model
{
    public class PickupResponse
    {
        public PickupResponse(IEnumerable<PickupPoint> pickupPoints)
        {
            PickupPoints = pickupPoints ?? Enumerable.Empty<PickupPoint>();
        }

        [JsonConverter(typeof(ObjectToArrayConverter<PickupPoint>))]
        [JsonProperty("pickupPoint")]
        public IEnumerable<PickupPoint> PickupPoints { get; private set; }
    }
}