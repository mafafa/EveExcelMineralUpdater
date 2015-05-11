using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.NotifyProperty;

namespace Data.APIRequests
{
    public interface IRequest
    {
        ReturnDataType DataReturnType { get; }

        String RequestURL { get; }
    }
    
    public enum ReturnDataType
    {
        Xml,
        Json
    };
}
