using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.NotifyProperty;

namespace Data.APIRequests
{
    public class QuickLookOnPathRequest : BindableObject, IRequest
    {
        private uint _setHours = 360;    // API's default value
        private uint _typeID = uint.MaxValue;
        private uint _setMinQ = 1;  // API's default value
        private uint _startPathSystemID = uint.MaxValue;
        private uint _endPathSystemID = uint.MaxValue;

        public QuickLookOnPathRequest()
        {
            
        }

        public ReturnDataType DataReturnType
        {
            get { return ReturnDataType.Xml; }
        }

        public String RequestURL
        {
            get
            {
                String url = Constants.EVECENTRAL_API_BASE_URL + Constants.QUICKLOOK_ONPATH_HTTP_QUERY_URL;
                url += @"from/" + StartPathSystemID + @"/";
                url += @"to/" + EndPathSystemID + @"/";
                url += @"fortype/" + TypeID + @"/";
                if (SetHours != uint.MaxValue)
                {
                    url += @"sethours/" + SetHours + @"/";
                }
                if (SetMinQ != uint.MaxValue)
                {
                    url += @"setminQ/" + SetMinQ + @"/";
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

        public uint StartPathSystemID
        {
            get { return _startPathSystemID; }
            set
            {
                if (_startPathSystemID != value)
                {
                    _startPathSystemID = value;
                    RaisePropertyChanged();
                }
            }
        }

        public uint EndPathSystemID
        {
            get { return _endPathSystemID; }
            set
            {
                if (_endPathSystemID != value)
                {
                    _endPathSystemID = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
