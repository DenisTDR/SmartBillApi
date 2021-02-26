using System.IO;
using System.Threading.Tasks;
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
    public interface IInvoiceService
    {
        Task<string> CreateInvoice(Invoice invoice);

        Stream GetInvoicePdf(string cif, string seriesName, string number);

        string DeleteInvoice(string cif, string seriesName, string number);

        string CancelInvoice(string cif, string seriesName, string number);

        string RestoreInvoice(string cif, string seriesName, string number);
    }
}