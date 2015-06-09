using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Data;

namespace Core.DataLayer
{
    public class XmlDataLayerAccessor : IDataLayerAccessor
    {
        private XDocument _xmlFile;
        
        public XmlDataLayerAccessor()
        {
            _xmlFile = new XDocument();
        }

        public void LoadDataLayer()
        {
            try
            {
                _xmlFile = XDocument.Load(FilePath);
            }
            catch (FileNotFoundException exception)
            {
                throw new FileNotFoundException(
                    "Could not find EveIDs.xml, please make sur the file is still in the right directory.");
            }
            catch (Exception exception)
            {
                throw new Exception("There was an error reading the EveIDs.xml file.");
            }
        }

        public uint? GetItemID(String itemName)
        {
            itemName = AddDashInString(itemName);
            
            IEnumerable<uint?> ids = _xmlFile.Descendants("Item_Types").Descendants()
                .Where(x => x.Name.LocalName == itemName)
                .Select(t => (uint?)(t.Attributes()
                    .FirstOrDefault(a => a.Name.LocalName == "ID")));

            return ids.FirstOrDefault();
        }

        public String GetItemName(uint id)
        {
            IEnumerable<String> names = _xmlFile.Descendants("Item_Types").Descendants()
                .Where(x => (uint?)(x.Attributes()
                    .FirstOrDefault(a => a.Name.LocalName == "ID")) == id)
                .Select(t => t.Name.LocalName);

            return RemoveDashFromString(names.FirstOrDefault()) ?? "";
        }

        public uint GetSystemID(uint id)
        {
            throw new NotImplementedException("This function has not yet been implemented.");
        }

        public String GetSystemName(String systemName)
        {
            throw new NotImplementedException("This function has not yet been implemented.");
        }

        public ICollection<EveItem> GetItems(EveItem.ItemTypes? itemType = null)
        {
            ICollection<EveItem> items = new List<EveItem>();
            
            if (itemType != null)
            {
                items = _xmlFile.Descendants(itemType.ToString()).Descendants()
                    .Where(x => x.Attribute("ID") != null)
                    .Select(x => new EveItem(x.Name.LocalName,
                        (uint)x.Attributes().FirstOrDefault(a => a.Name.LocalName == "ID"),
                        (EveItem.ItemTypes)itemType,
                        RemoveDashFromString(x.Parent.Name.LocalName))).ToList();
            }
            else
            {
                items = _xmlFile.Descendants()
                    .Where(x => x.Attribute("ID") != null)
                    .Select(x => new EveItem(x.Name.LocalName,
                        (uint) x.Attributes().FirstOrDefault(a => a.Name.LocalName == "ID"),
                        (EveItem.ItemTypes)Enum.Parse(typeof(EveItem.ItemTypes), x.Parent.Parent.Name.LocalName, true),
                        RemoveDashFromString(x.Parent.Name.LocalName))).ToList();
            }

            foreach (EveItem item in items)
            {
                item.ItemName = RemoveDashFromString(item.ItemName);
            }

            return items;
        }

        private String AddDashInString(String str)
        {
            return str.Replace(" ", "_");
        }

        private String RemoveDashFromString(String str)
        {
            return str.Replace("_", " ");
        }

        public String FilePath
        {
            get { return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\EveIDs.xml"; }
        }
    }
}
