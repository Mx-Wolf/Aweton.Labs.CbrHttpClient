using System.Text;
using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;
public class CbrHttpGet : ICbrHttpGet
{
  private const string _url = "https://cbr.ru/scripts/XML_daily.asp";
  private const string _field = "date_req";
  private const string _dateFS = "dd/MM/yyyy";
  private readonly HttpClient m_HttpClient;
  public CbrHttpGet(HttpClient httpClient)
  {
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    m_HttpClient = httpClient;
  }
  public async Task<string> GetXmlDailyAsp(DateTime date)
  {
    var url = $"{_url}?{_field}={date.ToString(_dateFS)}";
    var rs = await m_HttpClient.GetAsync(url);
    if (rs.IsSuccessStatusCode)
    {
      //using var sr = new StreamReader(await rs.Content.ReadAsStreamAsync(), Encoding.GetEncoding(1251));
      //return await sr.ReadToEndAsync();
      return await rs.Content.ReadAsStringAsync();
    }
    throw new Exception($"{rs.StatusCode} - ${rs.ReasonPhrase}");
  }
}
