using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;

namespace SmartBillApi.Rest
{
    public class NewtonsoftJsonSerializer : ISerializer
    {
        private static JsonSerializerSettings _serializerSettings;

        public static JsonSerializerSettings SerializerSettings => _serializerSettings ??= new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.Ignore,
        };

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public string ContentType { get; set; } = "application/json";
    }
}