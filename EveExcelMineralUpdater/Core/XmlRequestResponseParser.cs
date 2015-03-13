using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using Data;
using Data.APIRequests;

namespace Core
{
    public class XmlRequestResponseParser : IApiRequestResponseParser
    {
        private List<String> _filters;
        private String _rawRequestResponse;
        private List<ParsedApiAnswer> _parsedResponsesList;
        
        public XmlRequestResponseParser(String rawResponse)
        {
            Filters = new List<String>();
            _parsedResponsesList = new List<ParsedApiAnswer>();
            
            _rawRequestResponse = rawResponse;
        }

        public XmlRequestResponseParser(String rawResponse, String filter)
        {
            Filters = new List<String>();
            _parsedResponsesList = new List<ParsedApiAnswer>();

            Filters.Add(filter);
            _rawRequestResponse = rawResponse;
        }

        public XmlRequestResponseParser(String rawResponse, IEnumerable<String> filters)
        {
            Filters = new List<String>(filters);
            _parsedResponsesList = new List<ParsedApiAnswer>();

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

        public void ReinitialiseFilters()
        {
            Filters = new List<String>();
        }

        public void Parse()
        {
            // Reinitialise the ParsedApiAnswer list
            _parsedResponsesList = new List<ParsedApiAnswer>();
            
            // We create the Xml structure from the raw response
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.LoadXml(RawRequestResponse);
            }
            catch (XmlException ex)
            {
                throw new XmlException("Xml raw response not properly formed. An error probably occured in the " + 
                    "reception of the response from the API server.");
            }
            
            // Parse for each filter
            foreach (String filter in Filters)
            {
                try
                {
                    XmlNode excelFilePathNode = xmlDocument.SelectSingleNode(filter);

                    _parsedResponsesList.Add(new ParsedApiAnswer(filter, excelFilePathNode.InnerText));
                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException("Could not parse the following filter: " + filter);
                }
                catch (XPathException ex)
                {
                    throw new XmlException("Could not parse the following filter: " + filter);
                }
            }
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

        public List<ParsedApiAnswer> ParsedResponsesList
        {
            get { return _parsedResponsesList; }
        }

        public bool HasParsedSinceLastFilterAddOrRemove
        {
            get
            {
                if (Filters.Count != ParsedResponsesList.Count)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
