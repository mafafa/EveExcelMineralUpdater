﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.APIRequests
{
    public class MarketStatRequest : IRequest
    {
        public ReturnDataType DataReturnType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Net.HttpWebRequest HttpRequest
        {
            get { throw new NotImplementedException(); }
        }
    }
}
