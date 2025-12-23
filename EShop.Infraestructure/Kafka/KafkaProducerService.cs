using Confluent.Kafka;
using EShop.Domain.Interfaces;
using System.Text.Json;

namespace EShop.Infraestructure.Kafka
{
    public class KafkaProducerService : IEventProducer
    {
        private readonly ProducerConfig _config;

        public KafkaProducerService(string bootstrapServers)
        {
            _config = new ProducerConfig { BootstrapServers = bootstrapServers };
        }

        public async Task ProduceAsync<T>(string topic, T message)
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();
            var jsonMessage = JsonSerializer.Serialize(message);

            var dr = await producer.ProduceAsync(topic, new Message<Null, string> { Value = jsonMessage });
            Console.WriteLine($"Evento enviado a {dr.TopicPartitionOffset}");
        }
    }
}
