using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RevenueServices.DumbJsonModels
{
    public class ColumnarDataToListConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }



        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = existingValue as List<T> ?? new List<T>();
            var obj = JObject.Load(reader);
            var columns = obj["DATA"]["Data"]["Fields"] as JArray;
            var data = obj["DATA"]["Data"]["Rows"] as JArray;
            if (data == null)
                return list;
            list.AddRange(data
                .Select(item => new JObject(columns?.Zip(item, (c, v) => new JProperty((string)c, v))))
                .Select(o => o.ToObject<T>(serializer)));
            return list;
        }



        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
