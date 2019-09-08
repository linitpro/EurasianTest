using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectDetailsComponent.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GetProjectDetailsViewModel
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Int64 Id { set; get; }

        /// <summary>
        /// Название проекта
        /// </summary>
        public String Name { set; get; }

        public Int64? UserId { set; get; }

        /// <summary>
        /// Администраторы проекта
        /// </summary>
        public List<GetProjectDetailsUserViewModel> AddedUsers { set; get; }

        /// <summary>
        /// Администраторы проекта, которых возможно добавить
        /// </summary>
        public List<GetProjectDetailsUserViewModel> Users { set; get; }
    }
}
