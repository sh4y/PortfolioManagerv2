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
            string[] arr = new DataManipulator().GetRawData(content);
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[arr.Length-1]);
            Console.Read();
        }
    }
}
