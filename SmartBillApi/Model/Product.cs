
using System;

namespace SmartBillApi.Model
{
  public class Product
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public string Code { get; set; }

    public string TranslatedName { get; set; }

    public string TranslatedMeasuringUnit { get; set; }

    public int? NumberOfItems { get; set; }

    public string MeasuringUnitName { get; set; }

    public string Currency { get; set; }

    public Decimal Quantity { get; set; }

    public Decimal Price { get; set; }

    public bool IsTaxIncluded { get; set; }

    public string TaxName { get; set; }

    public Decimal TaxPercentage { get; set; }

    public Decimal ExchangeRate { get; set; }

    public bool SaveToDb { get; set; }

    public string WarehouseName { get; set; }

    public bool IsService { get; set; }

    public bool IsDiscount { get; set; }

    public DiscountType? DiscountType { get; set; }

    public Decimal? DiscountPercentage { get; set; }

    public Decimal? DiscountValue { get; set; }

    public Decimal? DiscountTaxValue { get; set; }
  }
}
