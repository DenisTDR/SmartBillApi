
using System;

namespace SmartBillApi.Model
{
  public class PaymentStatus
  {
    public Decimal InvoiceTotalAmount { get; set; }

    public Decimal PaidAmount { get; set; }

    public Decimal UnpaidAmount { get; set; }
  }
}
