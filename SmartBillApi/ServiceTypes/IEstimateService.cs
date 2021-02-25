
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
  public interface IEstimateService
  {
    string CreateEstimate(Estimate estimate);

    byte[] GetEstimatePdf(string cif, string seriesName, string number);

    string DeleteEstimate(string cif, string seriesName, string number);

    string CancelEstimate(string cif, string seriesName, string number);

    string RestoreEstimate(string cif, string seriesName, string number);
  }
}
