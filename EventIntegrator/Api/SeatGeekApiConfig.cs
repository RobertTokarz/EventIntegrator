using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventIntegrator.Api
{
    public class SeatGeekApiConfig : RequestConfig, IRequestBuilder
    {
        private Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

        private string _url = "https://api.seatgeek.com/2/";

        private string _entity;

        private HttpMethod _method;

        public SeatGeekApiConfig(string entity, HttpMethod method)
        {
            AddParameter("client_id", "MjM3MTQ3Mzh8MTYzMzI2OTI5OC4xMDAxNg");
            AddParameter("client_secret", "fc2c7a9885e58ed1c5ff7f30372a44b294535e69992b4fe1017b61c2c9a4492b");
            SetUrl(entity);
            _entity = entity;
            _method = method;
        }

        public override string Url { get { return _url; } }

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
