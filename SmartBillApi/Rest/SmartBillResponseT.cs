using System.Net;

namespace SmartBillApi.Rest
{
    public class SmartBillResponse<T> : SmartBillResponseBase
    {
        public T Data { get; set; }

        public bool HasData => Data != null;
        public HttpStatusCode StatusCode { get; set; }
    }
}