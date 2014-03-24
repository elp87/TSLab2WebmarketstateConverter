using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;

namespace tsl2ur.lib
{
    public class ReportFormerReader
    {
        private List<CellFormat> _cellFormats;
        public ReportFormerReader()
        {
            Workbook workbook = Workbook.Load(@"C:\Users\Alexandr\Downloads\Journal(RTS).xls");
            Worksheet worksheet = workbook.Worksheets[0];
            List<CellFormat> cells = new List<CellFormat>();
            for (int i = 0; i < 18; i++)
            {
                CellFormat cell = worksheet.Cells[1, i].Format;
                cells.Add(cell);
            }

            this._cellFormats = cells;
        }

        public List<CellFormat> GetCellFormatList()
        {
            return this._cellFormats;
        }
    }
}
