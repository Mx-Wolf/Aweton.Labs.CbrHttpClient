using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;

public interface ICbrXmlDaily
{
  IXmlResult Parse(string xml);
}
