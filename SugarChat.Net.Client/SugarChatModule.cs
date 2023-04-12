using Autofac;
using SugarChat.Net.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
