using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;

internal class XmlRow : IXmlRow
{
  public XmlRow(string vchCode, double vcurs, double vnom)
  {
    VchCode = vchCode;
    Vcurs = vcurs;
    Vnom = vnom;
  }
  public string VchCode { get; }

  public double Vcurs { get; }

  public double Vnom { get; }
}
