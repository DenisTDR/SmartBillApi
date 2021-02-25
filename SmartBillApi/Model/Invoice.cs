
using System;
using System.Collections.Generic;

namespace SmartBillApi.Model
{
  public class Invoice
  {
    public string CompanyVatCode { get; set; }

    public Client Client { get; set; }

    public bool IsDraft { get; set; }

    public DateTime IssueDate { get; set; }

    public string SeriesName { get; set; }

    public string Number { get; set; }

    public string Currency { get; set; }

    public Decimal ExchangeRate { get; set; }

    public string Language { get; set; }

    public int Precision { get; set; }

    public string IssuerCnp { get; set; }

    public string IssuerName { get; set; }

    public string Aviz { get; set; }

    public DateTime DueDate { get; set; }

    public string Mentions { get; set; }

    public string Observations { get; set; }

    public string DelegateAuto { get; set; }

    public string DelegateIdentityCard { get; set; }

    public string DelegateName { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public bool UsePaymentTax { get; set; }

    public Decimal PaymentBase { get; set; }

    public Decimal ColectedTax { get; set; }

    public Decimal PaymentTotal { get; set; }

    public bool UseStock { get; set; }

    public string PaymentUrl { get; set; }

    public DocumentBusinessKey Estimate { get; set; }

    public List<Product> Products { get; set; }

    public InvoicePayment Payment { get; set; }

    public bool UseEstimateDetails { get; set; }
  }
}
