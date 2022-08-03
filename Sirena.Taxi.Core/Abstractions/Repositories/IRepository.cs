using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Core.Abstractions.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными для облегчения контроллеров.
    /// </summary>
    /// <typeparam name="T">Сущность-наследник BaseEntity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Выбрать все элементы в таблице.
        /// </summary>
        /// <returns>Коллекция элементов из таблицы.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Выбрать конкретный элемент по идентификатору.
        /// </summary>
        /// <param name="id">Id искомого объекта.</param>
        /// <returns>Запись из БД.</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Добавить запись в БД.
        /// </summary>
        /// <param name="entity">Объект для вставки.</param>
        /// <returns>Пустой таск.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Обновить запись в БД.
        /// </summary>
        /// <param name="entity">Объект с актуальными значениями.</param>
        /// <returns>Пустой таск.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Удалить запись из БД.
        /// </summary>
        /// <param name="id">Идентификатор записи, подлежащей удалению.</param>
        /// <returns>Пустой таск.</returns>
        Task DeleteAsync(Guid id);

    }
}
