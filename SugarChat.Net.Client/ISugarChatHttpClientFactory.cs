using Autofac;
using System.Collections.Generic;
using System.Net.Http;

namespace SugarChat.Net.Client
{
    public interface ISugarChatHttpClientFactory
    {
        HttpClient GetHttpClient();

        void SetHeaders(Dictionary<string, string> headers);
    }

    public class SugarChatHttpClientFactory : ISugarChatHttpClientFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        public Dictionary<string, string> _headers { get; set; }

        public SugarChatHttpClientFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            var canResolve = _lifetimeScope.TryResolve(out IHttpClientFactory httpClientFactory);
            if (canResolve)
            {
                client = httpClientFactory.CreateClient();
            }
            if (_headers != null)
            {
                foreach (var header in _headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            return client;
        }

        public void SetHeaders(Dictionary<string, string> headers)
        {
            _headers = headers;
        }
    }
}
