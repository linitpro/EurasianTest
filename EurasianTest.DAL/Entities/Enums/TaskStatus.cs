using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Enums
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Новая задача
        /// </summary>
        New = 0,

        /// <summary>
        /// В работе
        /// </summary>
        Working = 1,

        /// <summary>
        /// Выполнена
        /// </summary>
        Done = 2,

        /// <summary>
        /// Закрыта
        /// </summary>
        Closed = 3,

        /// <summary>
        /// Возвращена
        /// </summary>
        Returned = 4,
    }
}
