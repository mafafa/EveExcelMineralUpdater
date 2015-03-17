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
    public class CfgFileSerializer : ISerializer
    {
        private XmlCfgFile _cfgFile;
        
        public CfgFileSerializer(XmlCfgFile cfgFile)
        {
            _cfgFile = cfgFile;
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CFGFile.ConfigFilePath);

            doc.SelectSingleNode(Constants.CFG_EXCEL_FILEPATH_XML_NODE_NAME).InnerText = CFGFile.ExcelFilePath;
            doc.SelectSingleNode(Constants.CFG_EXCEL_PRICE_COLUMN_XML_NODE_NAME).InnerText = CFGFile.ExcelPriceColumn;
            doc.SelectSingleNode(Constants.CFG_EXCEL_PRICE_ROW_START_XML_NODE_NAME).InnerText = CFGFile.ExcelPriceRowStart.ToString();
            doc.SelectSingleNode(Constants.CFG_EXCEL_PRICE_ROW_END_XML_NODE_NAME).InnerText = CFGFile.ExcelPriceRowEnd.ToString();

            doc.Save(CFGFile.ConfigFilePath);
        }

        public void Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CFGFile.ConfigFilePath);

            XmlNode excelFilePathNode = doc.SelectSingleNode(Constants.CFG_ROOT_XML_NODE_NAME + "/" +
                Constants.CFG_EXCEL_FILEPATH_XML_NODE_NAME);
            if (excelFilePathNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            CFGFile.ExcelFilePath = excelFilePathNode.InnerText;

            XmlNode excelPriceColumnNode = doc.SelectSingleNode(Constants.CFG_ROOT_XML_NODE_NAME + "/" +
                Constants.CFG_EXCEL_PRICE_COLUMN_XML_NODE_NAME);
            if (excelPriceColumnNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            CFGFile.ExcelPriceColumn = excelPriceColumnNode.InnerText;

            XmlNode excelPriceRowStartNode = doc.SelectSingleNode(Constants.CFG_ROOT_XML_NODE_NAME + "/" +
                Constants.CFG_EXCEL_PRICE_ROW_START_XML_NODE_NAME);
            if (excelPriceRowStartNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            UInt64 rowStart;
            if (UInt64.TryParse(excelPriceRowStartNode.InnerText, out rowStart))
            {
                CFGFile.ExcelPriceRowStart = rowStart;
            }
            else
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }

            XmlNode excelPriceRowEndNode = doc.SelectSingleNode(Constants.CFG_ROOT_XML_NODE_NAME + "/" +
                Constants.CFG_EXCEL_PRICE_ROW_END_XML_NODE_NAME);
            if (excelPriceRowEndNode == null)
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
            UInt64 rowEnd;
            if (UInt64.TryParse(excelPriceRowEndNode.InnerText, out rowEnd))
            {
                CFGFile.ExcelPriceRowEnd = rowEnd;
            }
            else
            {
                throw new CfgFileNotWellDefinedException("settings.cfg file not well defined. A default one shall " +
                                                         "be created now.");
            }
        }

        public void CreateDefaultConfigFile()
        {
            XmlDocument doc = new XmlDocument();

            XmlNode decNode = doc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty);
            doc.AppendChild(decNode);

            XmlNode settingsNode = doc.CreateElement(Constants.CFG_ROOT_XML_NODE_NAME);
            doc.AppendChild(settingsNode);

            XmlNode excelFilePathNode = doc.CreateElement(Constants.CFG_EXCEL_FILEPATH_XML_NODE_NAME);
            excelFilePathNode.InnerText = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\Minerals.xlsx";
            settingsNode.AppendChild(excelFilePathNode);

            XmlNode excelPriceColumnNode = doc.CreateElement(Constants.CFG_EXCEL_PRICE_COLUMN_XML_NODE_NAME);
            excelPriceColumnNode.InnerText = "A";
            settingsNode.AppendChild(excelPriceColumnNode);

            XmlNode excelPriceRowStartNode = doc.CreateElement(Constants.CFG_EXCEL_PRICE_ROW_START_XML_NODE_NAME);
            excelPriceRowStartNode.InnerText = "1";
            settingsNode.AppendChild(excelPriceRowStartNode);

            XmlNode excelPriceRowEndNode = doc.CreateElement(Constants.CFG_EXCEL_PRICE_ROW_END_XML_NODE_NAME);
            excelPriceRowEndNode.InnerText = "2";
            settingsNode.AppendChild(excelPriceRowEndNode);

            doc.Save(CFGFile.ConfigFilePath);
        }

        public XmlCfgFile CFGFile
        {
            get { return _cfgFile; }
        }
    }
}
