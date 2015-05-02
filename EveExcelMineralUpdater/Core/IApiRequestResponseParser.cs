﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.APIRequests;

namespace Core
{
    public interface IApiRequestResponseParser<T>
    {
        void Parse();

        String RawRequestResponse { get; }

        List<T> ParsedMarketOrders { get; }
    }
}
