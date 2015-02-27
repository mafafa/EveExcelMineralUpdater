using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Core.Exceptions;
using Data;

namespace Core
{
    public class CfgFileSerializer
    {
        private XMLCfgFile _cfgFile;
        
        public CfgFileSerializer(XMLCfgFile cfgFile)
        {
            _cfgFile = cfgFile;
        }

        public void SaveFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CFGFile.ConfigFilePath);

            doc.SelectSingleNode(Constants.EXCEL_FILEPATH_XML_NODE_NAME).InnerText = CFGFile.ExcelFilePath;
            doc.SelectSingleNode(Constants.EXCEL_PRICE_COLUMN_NAME_XML_NODE_NAME).InnerText = CFGFile.ExcelFilePath;

            doc.Save(CFGFile.ConfigFilePath);
        }

        public void LoadFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CFGFile.ConfigFilePath);

            XmlNode excelFilePathNode = doc.SelectSingleNode(Constants.EXCEL_FILEPATH_XML_NODE_NAME);
            if (excelFilePathNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            CFGFile.ExcelFilePath = excelFilePathNode[Constants.EXCEL_FILEPATH_XML_NODE_NAME].InnerText;

            XmlNode excelPriceColumnNameNode = doc.SelectSingleNode(Constants.EXCEL_PRICE_COLUMN_NAME_XML_NODE_NAME);
            if (excelPriceColumnNameNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            CFGFile.ExcelPriceColumnName = excelPriceColumnNameNode[Constants.EXCEL_PRICE_COLUMN_NAME_XML_NODE_NAME].InnerText;
        }

        public void CreateDefaultConfigFile()
        {
            XmlDocument doc = new XmlDocument();

            XmlNode decNode = doc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty);
            doc.AppendChild(decNode);

            XmlNode settingsNode = doc.CreateElement(Constants.ROOT_XML_NODE_NAME);
            doc.AppendChild(settingsNode);

            XmlNode excelFilePathNode = doc.CreateElement(Constants.EXCEL_FILEPATH_XML_NODE_NAME);
            excelFilePathNode.InnerText = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\Minerals.xlsx";
            settingsNode.AppendChild(excelFilePathNode);

            XmlNode excelPriceColumnNameNode = doc.CreateElement(Constants.EXCEL_PRICE_COLUMN_NAME_XML_NODE_NAME);
            excelPriceColumnNameNode.InnerText = @"Price/unit";
            settingsNode.AppendChild(excelPriceColumnNameNode);

            doc.Save(CFGFile.ConfigFilePath);
        }

        public XMLCfgFile CFGFile
        {
            get { return _cfgFile; }
        }
    }
}
