
using System;

namespace SmartBillApi.Model
{
  public class StockProduct
  {
    public string MeasuringUnit { get; set; }

    public string ProductCode { get; set; }

    public string ProductName { get; set; }

    public Decimal Quantity { get; set; }
  }
}
