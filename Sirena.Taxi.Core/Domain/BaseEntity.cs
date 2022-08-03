namespace Sirena.Taxi.Core.Domain
{
    /// <summary>
    /// Базовая сущность для использования в абстракциях.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public Guid Id { get; set; }
    }
}
