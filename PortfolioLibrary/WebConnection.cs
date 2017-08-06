using System;
using System.IO;
using System.Net;
using System.Text;

namespace PortfolioLibrary
{
    public class WebConnection : IWebConnection
    {
        public const string InvalidUrlError = "ERROR: INVALID URL SUPPLIED";

        public string DownloadPageContent(string url)
        {
            var data = "";
            try
            {
                var req = (HttpWebRequest) WebRequest.Create(url);
                var res = (HttpWebResponse) req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = res.GetResponseStream();
                    StreamReader readStream = null;
                    if (receiveStream != null)
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(res.CharacterSet));
                    if (readStream != null)
                        data = readStream.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                return InvalidUrlError;
            }
            return data;
        }

        /// <summary>
        ///     Creates a Google Finance link given a Ticker, Time period in days, and
        ///     tick data in seconds.
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="period"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string CreateConnectionString(string ticker, int period, int time)
        {
            ticker = ticker.ToUpper();
            return $"https://www.google.com/finance/getprices?i={time}&p={period}d&f=d,o,h,l,c,v&df=cpct&q={ticker}";
        }
    }

    public interface IWebConnection
    {
        string DownloadPageContent(string url);

        string CreateConnectionString(string ticker, int period, int time);
    }
}