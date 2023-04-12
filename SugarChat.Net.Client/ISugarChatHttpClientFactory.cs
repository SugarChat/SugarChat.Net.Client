using Autofac;
using System.Net.Http;

namespace SugarChat.Net.Client
{
    public interface ISugarChatHttpClientFactory
    {
        HttpClient GetHttpClient();
    }

    public class SugarChatHttpClientFactory : ISugarChatHttpClientFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        public SugarChatHttpClientFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public HttpClient GetHttpClient()
        {
            var canResolve = _lifetimeScope.TryResolve<IHttpClientFactory>(out IHttpClientFactory httpClientFactory);
            if (canResolve)
            {
                return httpClientFactory.CreateClient();
            }
            return new HttpClient();
        }
    }
}
