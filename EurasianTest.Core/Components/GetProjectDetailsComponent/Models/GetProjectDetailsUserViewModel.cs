using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectDetailsComponent.Models
{
    public class GetProjectDetailsUserViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Int64 UserId { set; get; }

        /// <summary>
        /// Эл. почта пользователя
        /// </summary>
        public String Email { set; get; }

        /// <summary>
        /// Флаг администратора проекта
        /// </summary>
        public Boolean IsProjectAdministrator { set; get; }

        public String EmailWithRole
        {
            get
            {
                return $"{(this.IsProjectAdministrator ? "PM" : "user")} {this.Email}";
            }
        }
    }
}
