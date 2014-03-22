using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tsl2ur.lib;

namespace tsl2ur.Test
{
    [TestClass]
    public class ConverterTradeTest
    {
        DateTime[] date = new DateTime[] 
            { 
                new DateTime(2014, 3, 21, 18, 29, 0),
                new DateTime(2001, 1, 1, 0, 0, 0)
            };

        Trade[] trades;
            

        public ConverterTradeTest()
        {
            trades = new Trade[]
            {
                new Trade() {EntryDateTime = new DateTime(2014, 3, 21, 18, 29, 0)},
                new Trade() {EntryDateTime = new DateTime(2001, 1, 1, 0, 0, 0)}
            };
        }

        [TestMethod]
        public void TestEntryDate()
        {
            string[] expDate = { "21.03.2014", "01.01.2001" };
            
            for (int i = 0; i < expDate.Length; i++)
            {
                Assert.AreEqual(expDate[i], trades[i].EntryDate);
            }
        }

        [TestMethod]
        public void TestEntryTime()
        {
            string[] expTime = { "18:29", "0:00" };

            for (int i = 0; i < expTime.Length; i++)
            {
                Assert.AreEqual(expTime[i], trades[i].EntryTime);
            }
        }

        [TestMethod]
        public void TestTsLabDate()
        {
            Trade[] tslTrades = new Trade[] { 
                new Trade() {TsLabEntryDateTime = "21.03.2014 18:29"},
                new Trade() {TsLabEntryDateTime = "01.01.2001 0:00"}
            };

            for (int i = 0; i < tslTrades.Length; i++)
            {
                Assert.AreEqual(trades[i].EntryDateTime, tslTrades[i].EntryDateTime);
            }
        }
    }
}
