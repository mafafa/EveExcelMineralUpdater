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
    public class XMLCfgFile : BindableObject
    {
        private readonly String _configFilePath;
        private String _excelFilePath;
        private String _excelPriceColumnName;
        
        public XMLCfgFile() : base()
        {
            _configFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\settings.cfg"; ;
            ExcelFilePath = null;
            ExcelPriceColumnName = null;
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

        public String ExcelPriceColumnName
        {
            get { return _excelPriceColumnName; }
            set
            {
                if (_excelPriceColumnName != value)
                {
                    _excelPriceColumnName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}