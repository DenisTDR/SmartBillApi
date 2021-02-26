using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using SmartBillApi.Extensions;
using SmartBillApi.Model;
using SmartBillApi.Rest;
using SmartBillApi.ServiceTypes;

namespace SmartBillApi
{
    public class SmartBillApiClient : ISmartBillCloudApi
    {
        private readonly SmartBillRestClient _restClient;

        public SmartBillApiClient([NotNull] string username, [NotNull] string token) =>
            _restClient = new SmartBillRestClient(username, token);

        public SmartBillApiClient([NotNull] string baseUrl, [NotNull] string username, [NotNull] string token) =>
            _restClient = new SmartBillRestClient(username, token, baseUrl);

        public async Task<string> CreateInvoice(Invoice invoice)
        {
            var request = new RestRequest("invoice", Method.POST) {JsonSerializer = new NewtonsoftJsonSerializer()};
            request.AddJsonBody(invoice);
            var resp = await _restClient.Response<NoCustomResponse>(request);
            if (string.IsNullOrEmpty(resp.Number) && !invoice.IsDraft)
            {
                throw new Exception(resp.ErrorText);
            }

            return resp.Number;
        }

        public Stream GetInvoicePdf(string cif, string seriesName, string number)
        {
            var request = new RestRequest("invoice/pdf")
                .AddQueryParameter(nameof(cif), cif)
                .AddQueryParameter("seriesname", seriesName)
                .AddQueryParameter(nameof(number), number)
                .AddHeader("Accept", "application/octet-stream");
            var memoryStream = new MemoryStream();
            request.AdvancedResponseWriter = (stream, httpResponse) =>
            {
                stream.CopyTo(memoryStream);
                stream.Dispose();
            };
            _restClient.Client.DownloadData(request);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public string DeleteInvoice(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();
            // RestRequest restRequest =
            // new RestRequest("invoice?cif={cif}&seriesname={seriesName}&number={number}", (Method) 3);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public string CancelInvoice(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();
            // RestRequest restRequest =
            // new RestRequest("invoice/cancel?cif={cif}&seriesname={seriesName}&number={number}", (Method) 2);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public string RestoreInvoice(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();
            // RestRequest restRequest =
            // new RestRequest("invoice/restore?cif={cif}&seriesname={seriesName}&number={number}", (Method) 2);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public async Task<string> CreateEstimate(Estimate estimate)
        {
            var request = new RestRequest("estimate", Method.POST) {JsonSerializer = new NewtonsoftJsonSerializer()};
            request.AddJsonBody(estimate);
            var resp = await _restClient.Response<NoCustomResponse>(request);
            if (string.IsNullOrEmpty(resp.Number))
            {
                throw new Exception(resp.ErrorText);
            }

            return resp.Number;
        }

        public Stream GetEstimatePdf(string cif, string seriesName, string number)
        {
            var request = new RestRequest("estimate/pdf")
                .AddQueryParameter(nameof(cif), cif)
                .AddQueryParameter("seriesname", seriesName)
                .AddQueryParameter(nameof(number), number)
                .AddHeader("Accept", "application/octet-stream");
            var memoryStream = new MemoryStream();
            request.AdvancedResponseWriter = (stream, httpResponse) =>
            {
                stream.CopyTo(memoryStream);
                stream.Dispose();
            };
            _restClient.Client.DownloadData(request);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task<string> DeleteEstimate(string cif, string seriesName, string number)
        {
            var request = new RestRequest("estimate", Method.DELETE)
                .AddQueryParameter(nameof(cif), cif)
                .AddQueryParameter("seriesname", seriesName)
                .AddQueryParameter(nameof(number), number);
            var resp = await _restClient.Response<NoCustomResponse>(request);
            return resp.Message;
        }

        public string CancelEstimate(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();

            // RestRequest restRequest =
            // new RestRequest("estimate/cancel?cif={cif}&seriesname={seriesName}&number={number}", (Method) 2);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public string RestoreEstimate(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();

            // RestRequest restRequest =
            // new RestRequest("estimate/restore?cif={cif}&seriesname={seriesName}&number={number}", (Method) 2);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public PaymentResponse CreatePayment(Payment payment)
        {
            throw new NotImplementedException();
            // RestRequest postRequest = this._sbcRestClient.CreatePostRequest<Payment>(nameof (payment), payment.ToPayment());
            // SbcResponse response = payment.Type != PaymentType.Bon ? this._sbcRestClient.Execute<SbcResponse>((IRestRequest) postRequest) : (SbcResponse) this._sbcRestClient.Execute<SbcResponseBon>((IRestRequest) postRequest);
            // payment.Number = response.Number;
            // return response.ToPaymentResponse();
        }

        public string GetReceiptText(string cif, string receiptId)
        {
            throw new NotImplementedException();
            // RestRequest restRequest = new RestRequest("payment/text?cif={cif}&id={id}", (Method) 0);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment("id", receiptId);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message.Base64Decode();
        }

        public string DeletePaymentByReceipt(string cif, string seriesName, string number)
        {
            throw new NotImplementedException();

            // RestRequest restRequest =
            // new RestRequest("payment/chitanta?cif={cif}&seriesname={seriesName}&number={number}", (Method) 3);
            // restRequest.AddUrlSegment(nameof(cif), cif);
            // restRequest.AddUrlSegment(nameof(seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof(number), number);
            //return this._sbcRestClient.Execute((IRestRequest) restRequest).Message;
        }

        public string DeletePayment(PaymentToDelete payment) =>
            throw new NotImplementedException();
        // this._sbcRestClient.Execute((IRestRequest) this._sbcRestClient.CreateDeleteRequest<PaymentToDelete>(nameof (payment), payment.ToPaymentToDelete())).Message;

        public PaymentStatus GetPaymentStatus(
            string cif,
            string seriesName,
            string number)
        {
            throw new NotImplementedException();
            // RestRequest restRequest = new RestRequest("invoice/paymentstatus?cif={cif}&seriesname={seriesName}&number={number}", (Method) 0);
            // restRequest.AddUrlSegment(nameof (cif), cif);
            // restRequest.AddUrlSegment(nameof (seriesName), seriesName);
            // restRequest.AddUrlSegment(nameof (number), number);
            //// return this._sbcRestClient.Execute<PaymentStatus>((IRestRequest) restRequest).ToPaymentStatus();
            //
        }

        public IList<SeriesInfo> GetSeries(string cif, SeriesType? seriesType = null)
        {
            throw new NotImplementedException();
            // RestRequest restRequest1 = new RestRequest("series?cif={cif}", (Method) 0);
            // restRequest1.AddUrlSegment(nameof (cif), cif);
            // if (seriesType.HasValue)
            // {
            //   RestRequest restRequest2 = restRequest1;
            //   restRequest2.set_Resource(restRequest2.Resource + "&type={type}");
            //   restRequest1.AddUrlSegment("type", seriesType.ToString().ToLower());
            // }
            // List<SeriesInfo> seriesList = this._sbcRestClient.Execute<Series>((IRestRequest) restRequest1).SeriesList;
            // // ISSUE: reference to a compiler-generated field
            // if (SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 == null)
            // {
            //   // ISSUE: reference to a compiler-generated field
            //   // ISSUE: method pointer
            //   SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 = new Func<SeriesInfo, SeriesInfo>((object) null, __methodptr(\u003CGetSeries\u003Eb__0));
            // }
            // // ISSUE: reference to a compiler-generated field
            // Func<SeriesInfo, SeriesInfo> anonymousMethodDelegate1 = SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1;
            // return (IList<SeriesInfo>) ((IEnumerable<SeriesInfo>) Enumerable.Select<SeriesInfo, SeriesInfo>((IEnumerable<M0>) seriesList, (Func<M0, M1>) anonymousMethodDelegate1)).ToList<SeriesInfo>();
        }

        public IList<Tax> GetTaxes(string cif)
        {
            throw new NotImplementedException();
            // RestRequest restRequest1 = new RestRequest("tax?cif={cif}", (Method) 0);
            // restRequest1.set_XmlSerializer((ISerializer) new DotNetXmlSerializer());
            // RestRequest restRequest2 = restRequest1;
            // restRequest2.AddUrlSegment(nameof (cif), cif);
            // List<Tax> taxes = this._sbcRestClient.Execute<Taxes>((IRestRequest) restRequest2).Taxes;
            // // ISSUE: reference to a compiler-generated field
            // if (SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4 == null)
            // {
            //   // ISSUE: reference to a compiler-generated field
            //   // ISSUE: method pointer
            //   SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4 = new Func<Tax, Tax>((object) null, __methodptr(\u003CGetTaxes\u003Eb__3));
            // }
            // // ISSUE: reference to a compiler-generated field
            // Func<Tax, Tax> anonymousMethodDelegate4 = SmartBillApi.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4;
            // return (IList<Tax>) ((IEnumerable<Tax>) Enumerable.Select<Tax, Tax>((IEnumerable<M0>) taxes, (Func<M0, M1>) anonymousMethodDelegate4)).ToList<Tax>();
        }

        public string SendDocument(EmailDocument emailDoc)
        {
            throw new NotImplementedException();
            // SendMailResponse sendMailResponse = this._sbcRestClient.ExecuteNoCheck<SendMailResponse>((IRestRequest) this._sbcRestClient.CreatePostRequest<EmailDocument>("document/send", emailDoc.ToEmailDocument()));
            // return sendMailResponse.Status.Code == 0 ? sendMailResponse.Status.Message : throw new ServerException(sendMailResponse.Status.Message);
        }

        public async Task<IList<Stock>> GetStock(
            string cif,
            DateTime date,
            string warehouseName = null,
            string productName = null,
            string productCode = null)
        {
            if (string.IsNullOrEmpty(cif)) throw new ArgumentNullException(nameof(cif));
            var request = new RestRequest("stocks", Method.GET)
                .AddQueryParameter(nameof(cif), cif)
                .AddQueryParameter(nameof(date), date.ToSmartBillString())
                .AddOptionalQueryParameter(nameof(warehouseName), warehouseName)
                .AddOptionalQueryParameter(nameof(productName), productName)
                .AddOptionalQueryParameter(nameof(productCode), productCode);
            var resp = await _restClient.Response<List<Stock>>(request);
            return resp.Data;
        }
    }
}