using System.Collections.Generic;
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
    public interface IConfigService
    {
        IList<SeriesInfo> GetSeries(string cif, SeriesType? seriesType = null);

        IList<Tax> GetTaxes(string cif);
    }
}