using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventIntegrator.Api
{
    class TicketmasterApiConfig : RequestConfig, IRequestBuilder
    {

        private Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

        private string _url = "https://app.ticketmaster.com/discovery/v2/";

        private string _entity;

        private HttpMethod _method;

        public TicketmasterApiConfig(string entity, HttpMethod method)
        {
            AddParameter("apikey", "7elxdku9GGG5k8j0Xm8KWdANDgecHMV0");
            SetUrl(entity);
            _entity = entity;
            _method = method;
        }

        public override string Url { get { return _url; }  }

        public override string Entity { get { return _entity; } }

        public HttpRequestMessage RequestMessage()
        {           
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = GetUri();
            request.Method = _method;
            return request;
        }

        private void AddParameter(string key, string value)
        {
            _queryParameters.Add(key, value);
        }

        private void SetUrl(string entity)
        {
            _url += entity;
        }
         
        private Uri GetUri()
        {
            UriBuilder builder = new UriBuilder(_url);
            FormUrlEncodedContent content = new FormUrlEncodedContent(_queryParameters);
            var query = content.ReadAsStringAsync().Result;
            builder.Query = query;
            return builder.Uri;
        }
    }
}
