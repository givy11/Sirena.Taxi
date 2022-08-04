using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Core.Abstractions
{
    /// <summary>
    /// Клиент для работы со службой заказа такси.
    /// </summary>
    public interface ITaxiClient
    {
        /// <summary>
        /// Выполняет запрос к службе такси.
        /// </summary>
        /// <param name="entity">Результат запроса.</param>
        void RequestData(BaseEntity entity); 
    }
}
