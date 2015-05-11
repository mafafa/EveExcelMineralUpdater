using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.APIRequests;

namespace Core
{
    public class JsonApiResponseParser: IApiRequestResponseParser<MarketOrder>
    {
        public void Parse()
        {
            throw new NotImplementedException();
        }

        public string RawRequestResponse
        {
            get { throw new NotImplementedException(); }
        }

        public List<MarketOrder> ParsedMarketOrders
        {
            get { throw new NotImplementedException(); }
        }
    }
}
