using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class XmlRequestResponseParser : IApiRequestResponseParser
    {
        private List<String> _filters;
        private String _rawRequestResponse;
        
        public XmlRequestResponseParser(String rawResponse)
        {
            Filters = new List<String>();
            
            _rawRequestResponse = rawResponse;
        }

        public XmlRequestResponseParser(String rawResponse, String filter)
        {
            Filters = new List<String>();

            Filters.Add(filter);
            _rawRequestResponse = rawResponse;
        }

        public XmlRequestResponseParser(String rawResponse, IEnumerable<String> filters)
        {
            Filters = new List<String>(filters);

            _rawRequestResponse = rawResponse;
        }

        public bool AddFilter(String filter)
        {
            if (!Filters.Contains(filter))
            {
                Filters.Add(filter);
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFilter(String filter)
        {
            return Filters.Remove(filter);
        }

        public List<String> Parse()
        {
            
        }

        public List<String> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }

        public String RawRequestResponse
        {
            get { return _rawRequestResponse; }
        }
    }
}
