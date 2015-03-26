using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Core
{
    public class XlsxSerializer : ISerializer
    {
        private Application _excelApp;
        private Workbook _excelWorkbook;
        private Worksheet _excelWorksheet;
        
        private int _lastRow;
        private String _xlsxFilePath;
        private String _priceColumn;
        private int _startRow;
        private int _endRow;

        private List<float> _priceList;

        public XlsxSerializer(String xlsxFilePath, String pricecolumn, int startRow, int endRow)
        {
            PriceList = new List<float>();

            _xlsxFilePath = xlsxFilePath;

            _priceColumn = pricecolumn;
            _startRow = startRow;
            _endRow = endRow;

            _excelApp = new Application();
            _excelApp.Visible = false;
            _excelWorkbook = _excelApp.Workbooks.Open(xlsxFilePath);
            _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
            _lastRow = _excelWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row; 
        }

        public XlsxSerializer(String xlsxFilePath, String pricecolumn, int startRow, int endRow, List<float> priceList)
        {
            PriceList = priceList;

            _xlsxFilePath = xlsxFilePath;

            _priceColumn = pricecolumn;
            _startRow = startRow;
            _endRow = endRow;

            _excelApp = new Application();
            _excelApp.Visible = false;
            _excelWorkbook = _excelApp.Workbooks.Open(xlsxFilePath);
            _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
            _lastRow = _excelWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
        }

        public void Save()
        {
            if (_startRow != -1 && +_endRow != -1)
            {
                int i = _startRow;
                foreach (float price in PriceList)
                {
                    _excelWorksheet.Cells[i, ExcelColumnToInt(_priceColumn)] = price;
                    i++;
                }

                _excelWorkbook.Save();
            }
            else
            {
                // TODO: Manage error
            }
            
            _excelApp.Quit();
        }

        private int ExcelColumnToInt(String columnString)
        {
            return columnString.Select((c, i) =>
                ((c - 'A' + 1) * ((int)Math.Pow(26, columnString.Length - i - 1)))).Sum();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public String XlsxFilePath
        {
            get { return _xlsxFilePath; }
        }

        public List<float> PriceList
        {
            get { return _priceList; }
            set { _priceList = value; }
        }
    }
}
