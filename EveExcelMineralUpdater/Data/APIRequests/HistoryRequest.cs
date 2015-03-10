using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.APIRequests
{
    public class HistoryRequest : IRequest
    {
        public ReturnDataType DataReturnType
        {
            get { throw new NotImplementedException(); }
        }

        public String RequestURL
        {
            get { throw new NotImplementedException(); }
        }
    }
}
