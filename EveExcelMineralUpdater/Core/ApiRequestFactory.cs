using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.APIRequests;

namespace Core
{
    public class ApiRequestFactory
    {
        public enum ApiRequestType
        {
            Evemon,
            History,
            MarketStat,
            QuickLook,
            QuickLookOnPath,
            Route
        };
        
        public static IRequest CreateApiRequest(ApiRequestType requestType)
        {
            IRequest request = null;

            switch (requestType)
            {
                case ApiRequestType.Evemon:
                    request = new EvemonRequest();
                    break;
                
                case ApiRequestType.History:
                    request = new HistoryRequest();
                    break;

                case ApiRequestType.MarketStat:
                    request = new MarketStatRequest();
                    break;

                case ApiRequestType.QuickLook:
                    request = new QuickLookRequest();
                    break;

                case ApiRequestType.QuickLookOnPath:
                    request = new QuickLookOnPathRequest();
                    break;

                case ApiRequestType.Route:
                    request = new RouteRequest();
                    break;
            }

            return request;
        }
    }
}
