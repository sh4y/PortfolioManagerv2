using System;
using NUnit.Framework;
using PortfolioLibrary;

namespace PortfolioUnitTests
{
    public class MathTests
    {
        [Test]
        public void TestNdayMeanValues()
        {
            var pairs = new DataManipulator().GetDayInfoFromStrings(DataManipulationTests.MockData);
            var prices = new[] {pairs[0].Close, pairs[1].Close};
            Assert.AreEqual(60.02m, new StockMath().Mean(prices));
        }

        [Test]
        public void TestNdayVarianceValues()
        {
            var pairs = new DataManipulator().GetDayInfoFromStrings(DataManipulationTests.MockData);
            var prices = new[] { pairs[0].Close, pairs[1].Close };
            Assert.AreEqual(99.6004, new StockMath().VariancePopulation(prices));
        }

        [Test]
        public void TestNDayStdDev()
        {
            var pairs = new DataManipulator().GetDayInfoFromStrings(DataManipulationTests.MockData);
            var prices = new[] { pairs[0].Close, pairs[1].Close };
            Assert.AreEqual(Math.Sqrt(99.6004), new StockMath().StandardDeviationPopulation(prices));
        }
    }
}
