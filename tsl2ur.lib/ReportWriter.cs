using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                foreach (Trade trade in this._tradeList)
                {
                    worksheet.Cells[n, 0] = new Cell(n);
                    worksheet.Cells[n, 1] = new Cell(trade.EntryDate);
                    worksheet.Cells[n, 2] = new Cell(trade.EntryTime);
                    worksheet.Cells[n, 3] = new Cell(trade.ExitDate);
                    worksheet.Cells[n, 4] = new Cell(trade.ExitTime);
                    worksheet.Cells[n, 5] = new Cell(trade.InstrumentName);
                    worksheet.Cells[n, 6] = new Cell(trade.TradeType);
                    worksheet.Cells[n, 7] = new Cell(trade.EntryPrice);
                    worksheet.Cells[n, 8] = new Cell(trade.ExitPrice);
                    worksheet.Cells[n, 9] = new Cell(trade.Count);
                    worksheet.Cells[n, 10] = new Cell(trade.Fee);
                    worksheet.Cells[n, 11] = new Cell(trade.DollarPrice);
                    worksheet.Cells[n, 12] = new Cell(trade.EntryReason);
                    worksheet.Cells[n, 13] = new Cell(trade.ExitReason);
                    worksheet.Cells[n, 14] = new Cell(trade.Rating);
                    worksheet.Cells[n, 15] = new Cell(trade.Strategy);
                    worksheet.Cells[n, 16] = new Cell(trade.Comment);

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
