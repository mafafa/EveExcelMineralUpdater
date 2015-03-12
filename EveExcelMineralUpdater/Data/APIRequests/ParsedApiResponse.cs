using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.APIRequests
{
    public class ParsedApiAnswer
    {
        private String _filter;
        private String _response;

        public ParsedApiAnswer(String filter, String response)
        {
            _filter = filter;
            _response = response;
        }

        public String Filter
        {
            get { return _filter; }
        }

        public String Response
        {
            get { return _response; }
        }
    }
}
