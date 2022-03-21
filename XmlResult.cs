using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;

internal class XmlResult : IXmlResult
{
  private byte[]? hash;

public XmlResult(byte[] hash, IList<IXmlRow> rates, DateTime aDate)
{
    Rates=rates;
    this.hash = hash;
    ADate = aDate;

}
  public byte[] GetHash()
  {
    return hash ?? throw new InvalidOperationException();
  }


  public DateTime ADate { get; }

  public IList<IXmlRow> Rates { get; }
}
