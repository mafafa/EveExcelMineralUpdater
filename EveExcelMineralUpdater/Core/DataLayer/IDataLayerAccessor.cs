using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Core.DataLayer
{
    public interface IDataLayerAccessor
    {
        void LoadDataLayer();
        
        uint? GetItemID(String itemName);

        String GetItemName(uint id);

        uint GetSystemID(uint id);

        String GetSystemName(String systemName);

        ICollection<EveItem> GetItems(EveItem.ItemTypes? itemType = null);
    }
}
