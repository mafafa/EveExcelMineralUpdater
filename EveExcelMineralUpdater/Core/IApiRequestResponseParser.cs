using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IApiRequestResponseParser
    {
        bool AddFilter(String filter);

        bool RemoveFilter(String filter);

        List<String> Parse();
        
        List<String> Filters { get; set; }

        String RawRequestResponse { get; }
    }
}
