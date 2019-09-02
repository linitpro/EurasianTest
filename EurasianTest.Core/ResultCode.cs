using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core
{
    public enum ResultCode
    {
        Ok = 0,

        /// <summary>
        /// Пользователь уже существует
        /// </summary>
        UserAlreadyExist = -1000,

        /// <summary>
        /// Пользователь не найден
        /// </summary>
        UserNotFound = -1001,

        /// <summary>
        /// Некорректный пароль пользователя
        /// </summary>
        UserIncorrectPassword = -1002,
    }
}
