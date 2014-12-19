using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Geta.Bring.Shipping.Infrastructure
{
    internal class ObjectToArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Object || token.Type == JTokenType.String)
            {
                return new[] { token.ToObject<T>() };
            }

            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<T[]>();
            }

            throw new JsonSerializationException("Unexpected token type: " + token.Type);
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(T[]));
        }
    }
}