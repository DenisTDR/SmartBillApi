using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartBillApi.Model;

namespace SmartBillApi.ServiceTypes
{
    public interface IStockService
    {
        Task<IList<Stock>> GetStock(
            string cif,
            DateTime date,
            string warehouseName,
            string productName,
            string productCode);
    }
}