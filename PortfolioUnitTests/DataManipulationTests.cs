using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;
using PortfolioLibrary;

namespace PortfolioUnitTests
{
    public class DataManipulationTests
    {
        
        [Test]
        public void TestRawDataSlice()
        {
            StringBuilder sb = new StringBuilder();
            List<String> arr = new List<String>();

            for (int i = 0; i < 15; i ++)
            {
                sb.Append(i.ToString());
                if (i != 14)
                {
                    sb.Append('\n');
                }
                if (i >= 7)
                {
                    arr.Add(i.ToString());
                }
            }

            string[] result = new DataManipulator().getRawData(sb.ToString());

            Assert.AreEqual(arr.ToArray(), result);

        }
    }
}
