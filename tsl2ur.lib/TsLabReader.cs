using System;
using System.Collections.Generic;
using elp.Extensions;

namespace tsl2ur.lib
{
    public class TsLabReader
    {
        #region Fields
        private List<Trade> _tradeList;
        private Actions.ActionResult _result;
        #endregion

        #region Constructors
        private TsLabReader()
        {
            _tradeList = new List<Trade>();
            _result = Actions.ActionResult.None;
        }

        public TsLabReader(string fileName)
            :this()
        {
            CSVReader csv = new CSVReader(fileName, _tradeList);

            try
            {
                this._result = Actions.ActionResult.Success;
                
                csv.hasHeader = true;
                csv.AddColumn("TsLabTradeType", 0);
                csv.AddColumn("InstrumentName", 1);
                csv.AddColumn("Count", 2);
                csv.AddColumn("EntryReason", 3);
                csv.AddColumn("TsLabEntryDateTime", 5);
                csv.AddColumn("EntryPrice", 6);
                csv.AddColumn("ExitReason", 7);
                csv.AddColumn("TsLabExitDateTime", 9);
                csv.AddColumn("ExitPrice", 10);

                _tradeList = (List<Trade>)csv.finalList;
            }
            catch (Exception)
            {
                this._result = Actions.ActionResult.Error;
            }
        } 
        #endregion

        #region Properties
        public Actions.ActionResult ActionResult { get { return this._result; } }
        #endregion

        #region Methods
        public List<Trade> GetTradeList()
        {
            return this._tradeList;
        }
        #endregion
    }
}
