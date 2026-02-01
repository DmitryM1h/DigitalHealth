using KafkaMessaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Messaging
{
    public static class DependencyInjection
    {
        public static void AddKafkaConsumer<TMessage, THandler>(this IServiceCollection services, IConfigurationSection configurationSection)
            where THandler: class, IMessageHandler<TMessage>
        {
            services.Configure<KafkaSettings>(configurationSection);
            services.AddHostedService<KafkaConsumer<TMessage>>();
            services.AddSingleton<IMessageHandler<TMessage>, THandler>();
        } 
    }
}
