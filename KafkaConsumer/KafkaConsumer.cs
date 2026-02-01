using Confluent.Kafka;
using Kafka.Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KafkaMessaging
{
    public class KafkaConsumer<TMessage> : BackgroundService
    {
        private readonly string _topic;
        private readonly IConsumer<string, TMessage> _consumer;
        public IMessageHandler<TMessage> _messageHandler { get; }


        public KafkaConsumer(IOptions<KafkaSettings> kafkaSettings, IMessageHandler<TMessage> messageHandler)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaSettings.Value.BootstrapService,
                GroupId = kafkaSettings.Value.GroupId,
            };
            _topic = kafkaSettings.Value.Topic;

            _consumer = new ConsumerBuilder<string, TMessage>(config)
                .SetValueDeserializer(new KafkaValueDeserializer<TMessage>())
                .Build();
            _messageHandler = messageHandler;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => ConsumeAsync(stoppingToken), stoppingToken);
        }

        private async Task? ConsumeAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_topic);

            try
            {
                while(!stoppingToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume(stoppingToken);
                    await _messageHandler.HandleAsync(result.Message.Value, stoppingToken);
                }
            }
            catch (Exception e)
            {

            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}
