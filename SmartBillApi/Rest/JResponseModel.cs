using System.Net;
using Newtonsoft.Json.Linq;

namespace SmartBillApi.Rest
{
    public class JResponseModel
    {
        public JToken Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}