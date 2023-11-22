using Autofac;
using SugarChat.Net.Client.HttpClients;
using System;

namespace SugarChat.Net.Client
{
    public static class SugarChatModule
    {
        public static void AddSugarChatClient(this ContainerBuilder builder, string baseUrl, Action<SugarChatClientOptions, IComponentContext> setupAction)
        {
            builder.RegisterType<SugarChatHttpClientFactory>().As<ISugarChatHttpClientFactory>();
            builder.Register(c =>
            {
                var sugarChatHttpClientFactory = c.Resolve<ISugarChatHttpClientFactory>();
                SugarChatClientOptions options = new SugarChatClientOptions();
                setupAction(options, c);
                Configure(options, sugarChatHttpClientFactory);
                return new SugarChatHttpClient(baseUrl, sugarChatHttpClientFactory);
            }).As<ISugarChatClient>().InstancePerLifetimeScope();
        }

        public static void Configure(SugarChatClientOptions setupAction, ISugarChatHttpClientFactory sugarChatHttpClientFactory)
        {
            if (setupAction == null)
                return;

            sugarChatHttpClientFactory.SetHeaders(setupAction.Headers);
        }
    }
}
