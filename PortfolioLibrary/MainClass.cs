using System;

namespace PortfolioLibrary
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            WebConnection wc = new WebConnection();
            string url = wc.CreateConnectionString("amd", 5, 3600);
            string content = wc.DownloadPageContent(url);
            Console.Write(content);
            Console.Read();
        }
    }
}
