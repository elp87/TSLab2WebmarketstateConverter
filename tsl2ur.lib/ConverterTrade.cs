using System;


namespace tsl2ur.lib
{
    public class Trade : elp87.Trade
    {
        #region Properties
        public string EntryDate
        {
            get { return _entryDateTime.ToShortDateString(); }
        }

        public string EntryTime
        {
            get { return _entryDateTime.ToShortTimeString(); }
        }

        public string ExitDate
        {
            get { return _exitDateTime.ToShortDateString(); }
        }

        public string ExitTime
        {
            get { return _exitDateTime.ToShortTimeString(); }
        }

        public string TradeType
        {
            get
            {
                if (_isLong == true) return "L";
                else return "S";
            }
        }

        public double Fee { get; set; }

        public double DollarPrice { get; set; }

        public string EntryReason { get; set; }

        public string ExitReason { get; set; }

        public int Rating { get; set; }

        public string Strategy { get; set; }

        public string Comment { get; set; }

        public string TsLabEntryPrice
        {
            set { _entryPrice = Convert.ToDouble(value, System.Globalization.CultureInfo.CreateSpecificCulture("en")); }
        }

        public string TsLabExitPrice
        {
            set { _exitPrice = Convert.ToDouble(value, System.Globalization.CultureInfo.CreateSpecificCulture("en")); }
        }
        #endregion
    }
}
