﻿using System;

namespace elp87.Financial
{
    public class Trade
    {
        #region Fields
        protected DateTime _entryDateTime;
        protected DateTime _exitDateTime;
        protected double _entryPrice;
        protected double _exitPrice;
        protected int _count;
        protected string _instrumentName;
        protected bool _isLong;
        #endregion

        #region Properties
        public DateTime EntryDateTime
        {
            get { return _entryDateTime; }
            set { _entryDateTime = value; }
        }

        public DateTime ExitDateTime
        {
            get { return _exitDateTime; }
            set { _exitDateTime = value; }
        }

        public double EntryPrice
        {
            get { return _entryPrice; }
            set { _entryPrice = value; }
        }

        public double ExitPrice
        {
            get { return _exitPrice; }
            set { _exitPrice = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public double EntryVolume
        {
            get { return (_entryPrice * _count); }
        }

        public double ExitVolume
        {
            get { return (_exitPrice * _count); }
        }

        public string InstrumentName
        {
            get { return _instrumentName; }
            set { _instrumentName = value; }
        }

        public bool IsLong
        {
            get { return _isLong; }
            set { _isLong = value; }
        }
        #endregion
    }
}
