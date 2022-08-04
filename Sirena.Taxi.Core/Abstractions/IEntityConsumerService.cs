namespace Sirena.Taxi.Core.Abstractions
{
    /// <summary>
    /// Обработчик полученного сообщения из Kafka
    /// </summary>
    public interface IEntityConsumerService
    {
        Task Execute(string topic, string message);
    }
}
