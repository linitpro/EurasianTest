using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.OuterRegistrationComponent.Models
{
    /// <summary>
    /// Модель представления для внешней регистрации пользователя
    /// </summary>
    public class OuterRegistrationViewModel
    {
        /// <summary>
        /// Эл.почта
        /// </summary>
        public String Email { set; get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public String Password { set; get; }
    }
}
