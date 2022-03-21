using Aweton.Labs.Cbr.Abstractions;

namespace Aweton.Labs.CbrHttpClient;

public class CbrLoader : ICbrLoader
    {
        private readonly ICbrHttpGet m_CbrHttpGet;
        private readonly ICbrXmlDaily m_CbrXmlDaily;

        public CbrLoader(ICbrHttpGet cbrHttpGet, ICbrXmlDaily cbrXmlDaily)
        {
            m_CbrHttpGet = cbrHttpGet;
            m_CbrXmlDaily = cbrXmlDaily;
        }
        public async Task<IXmlResult> LoadFor(DateTime date)
        {
            var xml = await m_CbrHttpGet.GetXmlDailyAsp(date);
            return m_CbrXmlDaily.Parse(xml);
        }
    }
