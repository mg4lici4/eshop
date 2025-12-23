namespace EShop.Domain.Interfaces
{
    public interface IEventProducer
    {
        Task ProduceAsync<T>(string topic, T message);
    }
}
