using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Prices.Domain.Entities
{
    /// <summary>
    /// Стоимость поездки
    /// </summary>
    public class PriceRequest: BaseEntity
    {
        /// <summary>
        /// Адрес отправки
        /// </summary>
        public string DepartureAddress { get; set; }
        /// <summary>
        /// Долгота отправки
        /// </summary>
        public double DepartureLongitude { get; set; }
        /// <summary>
        /// Широта отправки
        /// </summary>
        public double DepartureLatitude { get; set; }
        /// <summary>
        /// Адрес точки назначения
        /// </summary>
        public string DestinationAddress { get; set; }
        /// <summary>
        /// Долгота назначения
        /// </summary>
        public double DestinationLongitude { get; set; }
        /// <summary>
        /// Широта назначения
        /// </summary>
        public double DestinationLatitude { get; set; }
        /// <summary>
        /// Цена заказа
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// Получен ответ
        /// </summary>
        public bool ResponseReceived { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
