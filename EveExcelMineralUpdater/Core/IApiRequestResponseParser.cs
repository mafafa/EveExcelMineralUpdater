using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data.APIRequests;

namespace Core
{
    public interface IApiRequestResponseParser
    {
        bool AddFilter(String filter);

        bool RemoveFilter(String filter);

        void ReinitialiseFilters();

        void Parse();
        
        List<String> Filters { get; set; }

        String RawRequestResponse { get; }

        List<ParsedApiAnswer> ParsedResponsesList { get; }

        bool HasParsedSinceLastFilterAddOrRemove { get; }
    }
}
