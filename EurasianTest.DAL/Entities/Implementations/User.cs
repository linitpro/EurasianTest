using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Implementations
{
    public class User : IEntity
    {
        public Int64 Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Эл.почта
        /// оно же логин пользователя для входа
        /// </summary>
        public String Email { set; get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public String Password { set; get; }

        /// <summary>
        /// Соль к паролю
        /// </summary>
        public String Salt { set; get; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public Role Role { set; get; }
    }
}
