
using System;

namespace SmartBillApi.Model
{
  public class InvoicePayment
  {
    public Decimal Value { get; set; }

    public string PaymentSeries { get; set; }

    public PaymentType Type { get; set; }

    public bool IsCash { get; set; }
  }
}
