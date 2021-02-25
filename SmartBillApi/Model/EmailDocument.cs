namespace SmartBillApi.Model
{
  public class EmailDocument
  {
    public string CompanyVatCode { get; set; }

    public string SeriesName { get; set; }

    public string Number { get; set; }

    public DocumentType Type { get; set; }

    public string Subject { get; set; }

    public string To { get; set; }

    public string Cc { get; set; }

    public string Bcc { get; set; }

    public string BodyText { get; set; }
  }
}
