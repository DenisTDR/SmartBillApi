
using System;

namespace SmartBillApi.Model
{
  public class PaymentToDelete
  {
    public string CompanyVatCode { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime PaymentDate { get; set; }

    public Decimal PaymentValue { get; set; }

    public string ClientName { get; set; }

    public string ClientCif { get; set; }

    public string InvoiceSeries { get; set; }

    public string InvoiceNumber { get; set; }
  }
}
