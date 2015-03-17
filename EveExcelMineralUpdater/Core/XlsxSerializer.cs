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

        public XlsxSerializer(String xlsxFilePath, String pricecolumn, String startRow, String endRow)
        {
            PriceList = new List<float>();

            _xlsxFilePath = xlsxFilePath;

            _priceColumn = pricecolumn;
            if (!int.TryParse(startRow, out _startRow))
            {
                _startRow = -1;
            }
            if (!int.TryParse(endRow, out _endRow))
            {
                _endRow = -1;
            }

            _excelApp = new Application();
            _excelApp.Visible = false;
            _excelWorkbook = _excelApp.Workbooks.Open(xlsxFilePath);
            _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
            _lastRow = _excelWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row; 
        }

        public XlsxSerializer(String xlsxFilePath, String pricecolumn, String startRow, String endRow, List<float> priceList)
        {
            PriceList = priceList;

            _xlsxFilePath = xlsxFilePath;

            _priceColumn = pricecolumn;
            if (!int.TryParse(startRow, out _startRow))
            {
                _startRow = -1;
            }
            if (!int.TryParse(endRow, out _endRow))
            {
                _endRow = -1;
            }

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
                    _excelWorksheet.Cells[i, _priceColumn] = price;
                    i++;
                }
            }
            else
            {
                // TODO: Manage error
            }
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
