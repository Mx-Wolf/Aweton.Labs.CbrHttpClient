using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;
using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;

public class CbrXmlDaily : ICbrXmlDaily
{
  private static readonly MD5 _md5 = MD5.Create();
  private static readonly CultureInfo _ruRu = CultureInfo.GetCultureInfo("ru-RU");
  public IXmlResult Parse(string xml)
  {
    using var r = new StringReader(xml);
    var d = new XPathDocument(r);

    var n = d.CreateNavigator();
    var n1 = n.Select("/ValCurs/@Date");
    n1.MoveNext();
    return new XmlResult
    (
      _md5.ComputeHash(Encoding.UTF8.GetBytes(xml)),
      MakeRates(n.Select("/ValCurs/Valute")),
      GetDate(n1.Current)
		);
  }

  private IList<IXmlRow> MakeRates(XPathNodeIterator x)
  {
    return x.Cast<XPathNavigator>().Select((n) => GetRow(n)).ToList();
  }

  private IXmlRow GetRow(XPathNavigator? n)
  {
		if(n==null){
			throw new ArgumentNullException(nameof(n));
		}
    return new XmlRow
    (
      GetStringValue(n.SelectSingleNode("CharCode")),
      GetDoubleValue(n.SelectSingleNode("Value")),
      GetDoubleValue(n.SelectSingleNode("Nominal"))
		);
  }

  private static string GetStringValue(XPathNavigator? n1)
  {
		if(n1==null){
			throw new ArgumentNullException(nameof(n1));
		}
    return n1.Value;
  }

  private static double GetDoubleValue(XPathNavigator? n)
  {
    if (n == null)
    {
      throw new ArgumentNullException(nameof(n));
    }
    var s = n.Value;
    return double.Parse(s, _ruRu);
  }

  private DateTime GetDate(XPathNavigator? x)
  {
    if (x == null)
    {
      throw new ArgumentNullException(nameof(x));
    }
    return DateTime.ParseExact(x.Value, "dd.MM.yyyy", null);
  }
}
