using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace SmartBillApi.Rest
{
    internal class SmartBillRestClient
    {
        private RestClient Client { get; }

        public SmartBillRestClient([NotNull] string username, [NotNull] string token,
            [NotNull] string baseUrl = "https://ws.smartbill.ro/SBORO/api/")
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrEmpty(token)) throw new ArgumentNullException(nameof(token));
            if (string.IsNullOrEmpty(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));

            Client = new RestClient(baseUrl) {Authenticator = new HttpBasicAuthenticator(username, token)};
        }

        internal async Task<JResponseModel> Response(IRestRequest request)
        {
            var rr = await Client.ExecuteAsync(request);
            return new JResponseModel
            {
                Data = JsonConvert.DeserializeObject<JToken>(rr.Content),
                StatusCode = rr.StatusCode
            };
        }

        public async Task<SmartBillResponse<T>> Response<T>(IRestRequest request) where T : class, new()
        {
            var jObjR = await Response(request);
            var fieldPathAttr = Utils.GetResponseFieldPathFromType<T>();

            var result = jObjR.Data.ToObject<SmartBillResponse<T>>()
                         ?? throw new Exception($"Couldn't parse response to '{typeof(SmartBillResponse<T>).Name}'.");
            result.StatusCode = jObjR.StatusCode;

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return result;
            }

            if (fieldPathAttr.IsFlat)
            {
                result.Data = jObjR.Data.ToObject<T>();
            }

            var path = fieldPathAttr.FieldPath.Split("/");
            var obj = jObjR.Data;
            foreach (var t in path)
            {
                if (!(obj is JObject jObj) || !jObj.TryGetValue(t, out var token))
                {
                    throw new Exception($"Couldn't find path: '{fieldPathAttr.FieldPath}' in response.");
                }

                obj = token;
            }

            result.Data = obj?.ToObject<T>();

            return result;
        }

        public Task<SmartBillResponse<T>> Response<T>(string url) where T : class, new()
        {
            var request = new RestRequest(url, DataFormat.Json);
            return Response<T>(request);
        }
    }
}