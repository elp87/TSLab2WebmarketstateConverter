using System;
using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;

namespace tsl2ur.lib
{
    public class ReportWriter
    {
        #region Fields
        private List<Trade> _tradeList;
        private Actions.ActionResult _result;
        #endregion

        #region Constructors
        public ReportWriter(List<Trade> trades)
        {
            this._tradeList = trades;
            this._result = Actions.ActionResult.None;
        }
        #endregion

        #region Properties
        public Actions.ActionResult ActionResult { get { return _result; } }
        #endregion

        #region Methods
        #region Public
        public void WriteReport(string fileName)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("journal");
            
            this.PrepareHeaders(worksheet);

            int n = 1;
            try
            {
                this._result = Actions.ActionResult.Success;

                ReportFormerReader former = new ReportFormerReader();
                List<CellFormat> cellFormats = former.GetCellFormatList();

                foreach (Trade trade in this._tradeList)
                {
                    worksheet.Cells[n, 0] = new Cell(n, cellFormats[0]);
                    worksheet.Cells[n, 1] = new Cell(40449, cellFormats[1]);
                    worksheet.Cells[n, 2] = new Cell(trade.EntryTime, cellFormats[2]);
                    worksheet.Cells[n, 3] = new Cell(40450, cellFormats[3]);
                    worksheet.Cells[n, 4] = new Cell(trade.ExitTime, cellFormats[4]);
                    worksheet.Cells[n, 5] = new Cell(trade.InstrumentName, cellFormats[5]);
                    worksheet.Cells[n, 6] = new Cell(trade.TradeType, cellFormats[6]);
                    worksheet.Cells[n, 7] = new Cell(trade.EntryPrice, cellFormats[7]);
                    worksheet.Cells[n, 8] = new Cell(trade.ExitPrice, cellFormats[8]);
                    worksheet.Cells[n, 9] = new Cell(trade.Count, cellFormats[9]);
                    worksheet.Cells[n, 10] = new Cell(6, cellFormats[10]);
                    worksheet.Cells[n, 11] = new Cell(31, cellFormats[11]);
                    worksheet.Cells[n, 12] = new Cell(trade.EntryReason, cellFormats[12]);
                    worksheet.Cells[n, 13] = new Cell(trade.ExitReason, cellFormats[13]);
                    worksheet.Cells[n, 14] = new Cell(2, cellFormats[14]);
                    worksheet.Cells[n, 15] = new Cell(trade.Strategy, cellFormats[15]);
                    worksheet.Cells[n, 16] = new Cell(trade.Comment, cellFormats[16]);
                    worksheet.Cells[n, 17] = new Cell("", cellFormats[17]);

                    n++;
                }
            }
            catch (Exception)
            {
                this._result = Actions.ActionResult.Error;
            }
            try
            {
                workbook.Worksheets.Add(worksheet);
                workbook.Save(fileName);
            }
            catch (Exception)
            {
                this._result = Actions.ActionResult.Error;
            }
        }        
        #endregion

        #region Private
        private void PrepareHeaders(Worksheet worksheet)
        {
            worksheet.Cells[0, 0] = new Cell("№");
            worksheet.Cells[0, 1] = new Cell("Дата");
            worksheet.Cells[0, 2] = new Cell("Время открытия");
            worksheet.Cells[0, 3] = new Cell("Дата закрытия");
            worksheet.Cells[0, 4] = new Cell("Время закрытия");
            worksheet.Cells[0, 5] = new Cell("Инструмент");
            worksheet.Cells[0, 6] = new Cell("Направление сделки");
            worksheet.Cells[0, 7] = new Cell("Цена открытия");
            worksheet.Cells[0, 8] = new Cell("Цена закрытия");
            worksheet.Cells[0, 9] = new Cell("кол-во");
            worksheet.Cells[0, 10] = new Cell("Комиссия");
            worksheet.Cells[0, 11] = new Cell("курс доллара");
            worksheet.Cells[0, 12] = new Cell("Способ входа в позицию");
            worksheet.Cells[0, 13] = new Cell("Способ выхода из позиции");
            worksheet.Cells[0, 14] = new Cell("Оценка трейда");
            worksheet.Cells[0, 15] = new Cell("Стратегия");
            worksheet.Cells[0, 16] = new Cell("Комментарий");
        }
        #endregion
        #endregion
    }
}
