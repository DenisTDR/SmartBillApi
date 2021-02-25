
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
  public interface IEmailService
  {
    string SendDocument(EmailDocument emailDoc);
  }
}
