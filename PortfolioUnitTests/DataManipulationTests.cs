using System;
using System.Collections.Generic;
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
                //14 is neglected because the last line in doc is a blank
                if (i >= 7 && i != 14)
                {
                    arr.Add(i.ToString());
                }
            }

            string[] result = new DataManipulator().GetRawData(sb.ToString());

            Assert.AreEqual(arr.ToArray(), result);

        }
    }
}
