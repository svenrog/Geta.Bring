using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Geta.Bring.Shipping.Infrastructure
{
    public class DefaultingPropertyConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            try
            {
                return token.ToObject<T>();
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
    }
}