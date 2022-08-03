using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Users.Domain.Entities
{
    /// <summary>
    /// Сущность "Пользователь".
    /// </summary>
    public class User: BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

    }
}
