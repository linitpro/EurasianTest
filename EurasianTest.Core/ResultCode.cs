using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core
{
    public enum ResultCode
    {
        Ok = 0,

        /// <summary>
        /// Неопознанная ошибка
        /// </summary>
        GenericError = -999,

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

        /// <summary>
        /// Проект не найден
        /// </summary>
        ProjectNotFound = -2000,

        /// <summary>
        /// Задача не найдена
        /// </summary>
        TasksNotFound = -3000,

    }
}
