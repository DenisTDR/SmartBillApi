
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
  public interface IInvoiceService
  {
    string CreateInvoice(Invoice invoice);

    byte[] GetInvoicePdf(string cif, string seriesName, string number);

    string DeleteInvoice(string cif, string seriesName, string number);

    string CancelInvoice(string cif, string seriesName, string number);

    string RestoreInvoice(string cif, string seriesName, string number);
  }
}
