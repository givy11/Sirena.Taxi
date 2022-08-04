namespace Sirena.Taxi.Core.Abstractions
{
    public interface IEntityConsumerService
    {
        Task Execute(string topic, string message);
    }
}
