using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.APIRequests;

namespace Core
{
    public class ApiHttpRequestBuilder
    {
        private IRequest _request;
        private String _response;

        public ApiHttpRequestBuilder(IRequest apiRequest)
        {
            _request = apiRequest;
        }
        
        public bool ExecuteRequest()
        {
            if (IsURLValid(Request.RequestURL))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Request.RequestURL);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);

                _response = streamReader.ReadToEnd();

                httpWebResponse.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsURLValid(String url)
        {
            Uri urlUri = new Uri(url);
            
            // We verify that the url is well constructed
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute) &&
                (urlUri.Scheme == Uri.UriSchemeHttp || urlUri.Scheme == Uri.UriSchemeHttps))
            {
                // We verify if the status code is ok
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                request.Timeout = 10000;

                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        response.Close();

                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public IRequest Request
        {
            get { return _request; }
        }

        public String Response
        {
            get { return _response; }
        }
    }
}
