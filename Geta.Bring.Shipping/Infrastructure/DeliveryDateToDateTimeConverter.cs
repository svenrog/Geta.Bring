using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Geta.Bring.Shipping.Infrastructure
{
    public class DeliveryDateToDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Object)
            {
                var year = token.Value<int?>("Year") ?? 0;
                var month = token.Value<int?>("Month") ?? 0;
                var day = token.Value<int?>("Day") ?? 0;
                var hour = token.Value<int?>("Hour") ?? 0;
                var minute = token.Value<int?>("Minute") ?? 0;

                return new DateTime(year, month, day, hour, minute, 0);
            }

            throw new JsonSerializationException("Unexpected token type: " + token.Type);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
    }
}