namespace Aweton.Labs.CbrHttpClient;

public interface ICbrHttpGet
{
  Task<string> GetXmlDailyAsp(DateTime date);
}
