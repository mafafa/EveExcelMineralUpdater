using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data.NotifyProperty;

namespace Data
{
    public class XmlCfgFile : BindableObject
    {
        private readonly String _configFilePath;
        private String _excelFilePath;
        private String _excelPriceColumn;
        private UInt64 _excelPriceRowStart;
        private UInt64 _excelPriceRowEnd;
        
        public XmlCfgFile()
        {
            _configFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\settings.cfg";
            ExcelFilePath = null;
            ExcelPriceColumn = "A";
            ExcelPriceRowStart = 1;
            ExcelPriceRowEnd = 2;
        }

        public String ConfigFilePath
        {
            get { return _configFilePath; }
        }

        public String ExcelFilePath
        {
            get { return _excelFilePath; }
            set
            {
                if (_excelFilePath != value)
                {
                    _excelFilePath = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String ExcelPriceColumn
        {
            get { return _excelPriceColumn; }
            set
            {
                if (_excelPriceColumn != value)
                {
                    _excelPriceColumn = value;
                    RaisePropertyChanged();
                }
            }
        }

        public UInt64 ExcelPriceRowStart
        {
            get { return _excelPriceRowStart; }
            set
            {
                if (_excelPriceRowStart != value)
                {
                    _excelPriceRowStart = value;
                    RaisePropertyChanged();
                }
            }
        }

        public UInt64 ExcelPriceRowEnd
        {
            get { return _excelPriceRowEnd; }
            set
            {
                if (_excelPriceRowEnd != value)
                {
                    _excelPriceRowEnd = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}