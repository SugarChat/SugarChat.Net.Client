using Autofac;
using SugarChat.Net.Client.HttpClients;

namespace SugarChat.Net.Client
{
    public static class SugarChatModule
    {
        public static void AddSugarChatClient(this ContainerBuilder builder, string baseUrl)
        {
            builder.RegisterType<SugarChatHttpClientFactory>().As<ISugarChatHttpClientFactory>();
            builder.Register(c =>
            {
                var sugarChatHttpClientFactory = c.Resolve<ISugarChatHttpClientFactory>();
                return new SugarChatHttpClient(baseUrl, sugarChatHttpClientFactory);
            }).As<ISugarChatClient>().InstancePerLifetimeScope();
        }
    }
}
