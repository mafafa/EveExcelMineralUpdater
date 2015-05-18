using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Data.NotifyProperty;

namespace Data
{
    public class EveItem : BindableObject
    {
        private ItemTypes _itemType;
        private uint _itemID;
        private String _itemName;
        private BitmapImage _icon;
        
        public EveItem()
        {
            
        }

        public ItemTypes ItemType
        {
            get { return _itemType; }
            set
            {
                if (_itemType != value)
                {
                    _itemType = value;
                    RaisePropertyChanged();
                }
            }
        }

        public uint ItemID
        {
            get { return _itemID; }
            set
            {
                if (_itemID != value)
                {
                    _itemID = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BitmapImage Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    RaisePropertyChanged();
                }
            }
        }

        public enum ItemTypes
        {
            Ore,
            Ice,
            Mineral,
            Pi
        }
    }
}
