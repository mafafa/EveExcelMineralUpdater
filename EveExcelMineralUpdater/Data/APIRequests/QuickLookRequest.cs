using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Data.NotifyProperty;

namespace Data.APIRequests
{
    public class QuickLookRequest : BindableObject, IRequest
    {
        private uint _setHours = 24;    // API's default value
        private uint _typeID = uint.MaxValue;
        private uint _setMinQ = 1;  // API's default value
        private ObservableCollection<uint> _regionLimit;
        private uint _useSystem = uint.MaxValue;
        
        public QuickLookRequest()
        {
            RegionLimit = new ObservableCollection<uint>();
        }
        
        public ReturnDataType DataReturnType
        {
            get { return ReturnDataType.Xml; }
        }

        public String RequestURL
        {
            get
            {
                String url = Constants.EVECENTRAL_API_BASE_URL + Constants.QUICKLOOK_HTTP_QUERY_URL;

                url += "typeid=" + TypeID;
                url += "&setminQ=" + SetMinQ;
                url += "&sethours=" + SetHours;
                
                if (RegionLimit.Count != 0)
                {
                    foreach (uint region in RegionLimit)
                    {
                        url += "&regionlimit=" + region;
                    }    
                }
                if (UseSystem != uint.MaxValue)
                {
                    url += "&usesystem=" + UseSystem;
                }

                return url;
            }
        }

        public uint SetHours
        {
            get { return _setHours; }
            set
            {
                if (_setHours != value)
                {
                    _setHours = value;
                    RaisePropertyChanged();
                }
            }
        }

        public uint TypeID
        {
            get { return _typeID; }
            set
            {
                if (_typeID != value)
                {
                    _typeID = value;
                    RaisePropertyChanged();
                }               
            }
        }

        public uint SetMinQ
        {
            get { return _setMinQ; }
            set
            {
                if (_setMinQ != value)
                {
                    _setMinQ = value;
                    RaisePropertyChanged();
                }                  
            }
        }

        public ObservableCollection<uint> RegionLimit
        {
            get { return _regionLimit; }
            set
            {
                if (_regionLimit != value)
                {
                    _regionLimit = value;
                    RaisePropertyChanged();
                }                  
            }
        }

        public uint UseSystem
        {
            get { return _useSystem; }
            set
            {
                if (_useSystem != value)
                {
                    _useSystem = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
