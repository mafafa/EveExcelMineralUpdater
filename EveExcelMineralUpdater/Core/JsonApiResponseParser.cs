using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class JsonApiResponseParser: IApiRequestResponseParser
    {
        public bool AddFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public List<string> Parse()
        {
            throw new NotImplementedException();
        }

        public List<string> Filters
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string RawRequestResponse
        {
            get { throw new NotImplementedException(); }
        }
    }
}
