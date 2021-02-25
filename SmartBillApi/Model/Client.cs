namespace SmartBillApi.Model
{
  public class Client
  {
    public string Name { get; set; }

    public string VatCode { get; set; }

    public string Code { get; set; }

    public string Address { get; set; }

    public string RegCom { get; set; }

    public bool IsTaxPayer { get; set; }

    public string Contact { get; set; }

    public string Phone { get; set; }

    public string City { get; set; }

    public string County { get; set; }

    public string Country { get; set; }

    public string Email { get; set; }

    public string Bank { get; set; }

    public string Iban { get; set; }

    public bool SaveToDb { get; set; }
  }
}
