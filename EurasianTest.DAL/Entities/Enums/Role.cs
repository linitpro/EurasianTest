using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Enums
{
    public enum Role
    {
        /// <summary>
        /// Администартор
        /// иммеет достцуп ко всем проектоам и задачам
        /// </summary>
        Administrator = 0,

        /// <summary>
        /// Администратор проектов
        /// иммет доступ к проектам, установленным администратором
        /// </summary>
        ProjectAdministrator = 1,

        /// <summary>
        /// Пользователь
        /// иммет доступ к задачам в которых учатсвует
        /// </summary>
        User = 2
    }
}
