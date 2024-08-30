using System.Text;
using Newtonsoft.Json;
using Ebiscon.CloudCart.Application.HttpClient.Enums;

namespace Ebiscon.CloudCart.Application.HttpClient
{
    public class HttpRequestBuilder<TRequest> : IHttpRequestBuilder
    {
        private TRequest request;
        private HttpMethod method;
        private string requestUri;
        private ContentType content;
        private readonly Dictionary<string, string> headers;

        public HttpRequestBuilder()
        {
            headers = new Dictionary<string, string>();
        }

        public HttpRequestBuilder(
            TRequest request,
            HttpMethod method,
            string requestUri)
        {
            this.request = request;
            this.method = method;
            this.requestUri = requestUri;
            headers = new Dictionary<string, string>();
        }

        public HttpRequestBuilder<TRequest> WithHttpMethod(HttpMethod method)
        {
            this.method = method;
            return this;
        }

        public HttpRequestBuilder<TRequest> ToEndpoint(string requestUri)
        {
            this.requestUri = requestUri;
            return this;
        }

        public HttpRequestBuilder<TRequest> AddHeader(string name, string value)
        {
            headers[name] = value;
            return this;
        }
        public HttpRequestBuilder<TRequest> WithRequest(TRequest request)
        {
            this.request = request;
            return this;
        }

        public HttpRequestBuilder<TRequest> WithContent(ContentType contentTypes)
        {
            content = contentTypes;
            return this;
        }

        public HttpRequestMessage Build()
        {

            var content = this.content switch
            {
                ContentType.applicationjson => HandleJsonContent(),
                ContentType.applicationxwwwformurlencoded => HandleUrlEncodedContent(),

                _ => throw new NotSupportedException($"Content type is not supported.")
            };

            var messageRequest = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            foreach (var header in headers)
                messageRequest.Headers.Add(header.Key, header.Value);

            return messageRequest;
        }

        private HttpContent HandleJsonContent()
        {
            var json = request == null ? string.Empty : JsonConvert.SerializeObject(request);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private HttpContent HandleUrlEncodedContent()
            => new FormUrlEncodedContent(request as Dictionary<string, string>);

    }
}
