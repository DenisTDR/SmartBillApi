
using System;
using System.Collections.Generic;

namespace SmartBillApi.Model
{
  public class Payment
  {
    public string CompanyVatCode { get; set; }

    public Client Client { get; set; }

    public DateTime IssueDate { get; set; }

    public string SeriesName { get; set; }

    public string Number { get; set; }

    public string Currency { get; set; }

    public Decimal ExchangeRate { get; set; }

    public string Language { get; set; }

    public int Precision { get; set; }

    public Decimal Value { get; set; }

    public string Text { get; set; }

    public string TranslatedText { get; set; }

    public bool IsDraft { get; set; }

    public bool UseStock { get; set; }

    public PaymentType Type { get; set; }

    public bool IsCash { get; set; }

    public string Observation { get; set; }

    public List<DocumentBusinessKey> Invoices { get; set; }

    public bool UseInvoiceDetails { get; set; }

    public Decimal ReceivedCash { get; set; }

    public Decimal ReceivedCard { get; set; }

    public Decimal ReceivedOrdinDePlata { get; set; }

    public Decimal ReceivedTicheteMasa { get; set; }

    public Decimal ReceivedTicheteCadou { get; set; }

    public Decimal ReceivedCec { get; set; }

    public Decimal ReceivedCredit { get; set; }

    public Decimal ReceivedCupon { get; set; }

    public Decimal ReceivedPuncteDeFidelitate { get; set; }

    public Decimal ReceivedBonuriValoareFixa { get; set; }

    public Decimal ReceivedMonedaAlternativa { get; set; }

    public List<Product> Products { get; set; }

    public bool ReturnFiscalPrinterText { get; set; }
  }
}
