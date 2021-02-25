using System.IO;
using System.Threading.Tasks;
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
    public interface IEstimateService
    {
        Task<string> CreateEstimate(Estimate estimate);

        Stream GetEstimatePdf(string cif, string seriesName, string number);

        string DeleteEstimate(string cif, string seriesName, string number);

        string CancelEstimate(string cif, string seriesName, string number);

        string RestoreEstimate(string cif, string seriesName, string number);
    }
}