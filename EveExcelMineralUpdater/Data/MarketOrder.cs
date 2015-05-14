using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Data.NotifyProperty;

namespace Data
{
    public class MarketOrder
    {
        private uint _orderID;
        private float _price;
        private uint _volumeRemaining;
        private EveItem _item;

        public MarketOrder(uint orderID, float price, uint volumeRemaining, EveItem item)
        {
            _orderID = orderID;
            _price = price;
            _volumeRemaining = volumeRemaining;
            _item = item;
        }

        public override string ToString()
        {
            return "OrderID = " + OrderID + ", Price = " + Price +
                ", Volume Remaining = " + VolumeRemaining + ", Item is: " + Item;
        }

        public uint OrderID
        {
            get { return _orderID; }
        }

        public float Price
        {
            get { return _price; }
        }

        public uint VolumeRemaining
        {
            get { return _volumeRemaining; }
        }

        public EveItem Item
        {
            get { return _item; }
        }
    }
}
