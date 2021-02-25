
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
  public interface IPaymentService
  {
    PaymentResponse CreatePayment(Payment payment);

    string GetReceiptText(string cif, string receiptId);

    string DeletePaymentByReceipt(string cif, string seriesName, string number);

    string DeletePayment(PaymentToDelete payment);

    PaymentStatus GetPaymentStatus(string cif, string seriesName, string number);
  }
}
