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
        private String _rawRequestResponse;
        private List<MarketOrder> _parsedMarketOrders;
        
        public XmlRequestResponseParser(String rawResponse)
        {
            _parsedMarketOrders = new List<MarketOrder>();
            
            _rawRequestResponse = rawResponse;
        }

        public void Parse()
        {
            // Reinitialise the ParsedApiAnswer list
            _parsedMarketOrders = new List<MarketOrder>();
            
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

            // We go get each orders that the response sends us back
            XmlNodeList orderNodeList;
            try
            {
                orderNodeList = xmlDocument.SelectNodes(Constants.API_RESPONSE_BUY_ORDER_NODE_XPATH);
            }
            catch (XPathException ex)
            {
                throw new XPathException("The API's response does not contain any market orders that match " + 
                    "the API request's parameters.");
            }
            
            // Parse
            if (orderNodeList != null && orderNodeList.Count != 0)
            {
                foreach (XmlNode orderNode in orderNodeList)
                {
                    try
                    {
                        UInt64 orderID;
                        float price;
                        UInt64 volumeRemaining;

                        XmlNode priceNode = orderNode.SelectSingleNode(Constants.API_RESPONSE_PRICE_FILTER);
                        XmlNode volumeRemainingNode =
                            orderNode.SelectSingleNode(Constants.API_RESPONSE_VOL_REMAINING_FILTER);

                        if (UInt64.TryParse(orderNode.Attributes["id"].Value, out orderID) &&
                            float.TryParse(priceNode.InnerText, out price) &&
                            UInt64.TryParse(volumeRemainingNode.InnerText, out volumeRemaining))
                        {
                            _parsedMarketOrders.Add(new MarketOrder((uint)orderID, price, (uint)volumeRemaining));
                        }
                    }
                    catch (XPathException ex)
                    {
                        // TODO: Manage exceptions
                        throw new XPathException();
                    }
                    catch (ArgumentException ex)
                    {
                        // TODO: Manage exceptions
                        throw new ArgumentException();
                    }
                    catch (NullReferenceException ex)
                    {
                        // TODO: Manage exceptions
                        throw new NullReferenceException();
                    }
                }
            }
        }

        public String RawRequestResponse
        {
            get { return _rawRequestResponse; }
        }

        public List<MarketOrder> ParsedMarketOrders
        {
            get { return _parsedMarketOrders; }
        }
    }
}
