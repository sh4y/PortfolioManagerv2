using System.Net;
using System.Net.Http;

namespace PortfolioLibrary
{
    public class WebConnection
    {
        /// <summary>
        ///     Creates a Google Finance link given a Ticker, Time period in days, and
        ///     tick data in seconds.
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="period"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string CreateConnectionString(string ticker, int period, int time)
        {
            return string.Format("https://www.google.com/finance/getprices?i={0}&p={1}d&f=d,o,h,l,c,v&df=cpct&q={2}",
                time, period, ticker);
        }

        public void DownloadPageContent(string url)
        {
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse) req.GetResponseAsync();
        }
    }
}