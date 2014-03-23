using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tsl2ur.lib;

namespace tsl2ur.Test
{
    [TestClass]
    public class TsLabReaderTest
    {
        [TestMethod]
        public void TestReader()
        {
            List<Trade> trades = new List<Trade>();
            TsLabReader reader = new TsLabReader(@"C:\Users\Elp\Documents\gitHub\TSLab2WebmarketstateConverter\tsl2ur.Test\bin\Debug\TestData\trades.csv");
            trades = reader.GetTradeList();

            int a = 1;
            a++;
        }
    }
}
