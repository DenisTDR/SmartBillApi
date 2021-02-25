
namespace SmartBillApi.ServiceTypes
{
  public interface ISmartBillCloudApi : 
    IInvoiceService,
    IEstimateService,
    IPaymentService,
    IConfigService,
    IEmailService,
    IStockService
  {
  }
}
