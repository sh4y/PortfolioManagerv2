﻿using System.Net;
using System.Text;
using FakeItEasy;
using NUnit.Framework;
using PortfolioLibrary;

namespace PortfolioUnitTests
{
    public class WebConnectionTests
    {
        private string _info;
        [SetUp]
        public void Init()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in DataManipulationTests.MockData)
            {
                sb.Append(line);
            }
            _info = sb.ToString();
        }

        [Test]
        public void TestWebConnectionString()
        {
            var connStr = new WebConnection().CreateConnectionString("MS", 2, 60);
            var expOutput = "https://www.google.com/finance/getprices?i=60&p=2d&f=d,o,h,l,c,v&df=cpct&q=MS";
            Assert.IsTrue(connStr == expOutput);
        }

        [TestCase("http://www.sh4y.me/unittest", "Stub")]
        [TestCase("http://www.sh4y.me/test", WebConnection.InvalidUrlError)]
        public void TestDownloadPageContent(string url, string expOutput)
        {
            var content = new WebConnection().DownloadPageContent(url);
            Assert.AreEqual(content, expOutput);
        }

        [Test]
        public void TestGetDailyStockDataFromTicker()
        {
            var wc = A.Fake<IWebConnection>();
            try
            {
                new WebConnection().GetDailyStockDataFromTicker("AMD", 1);
            } catch (WebException)
            {
                
            }
            A.CallTo(() => wc.GetDailyStockDataFromTicker("", 0)).WithAnyArguments().Returns(_info);

            Assert.AreEqual(wc.GetDailyStockDataFromTicker("AMD", 1), _info);
        }
    }
}