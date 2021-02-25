
using System.Collections.Generic;

namespace SmartBillApi.Model
{
  [ResponseFieldPath("list")]
  public class Stock
  {
    public List<StockProduct> Products { get; set; }

    public Warehouse Warehouse { get; set; }
  }
}
