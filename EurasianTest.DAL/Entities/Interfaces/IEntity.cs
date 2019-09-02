using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Interfaces
{
    /// <summary>
    /// Общий интерфейс для всех сущностей БД
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        Int64 Id { set; get; }

        /// <summary>
        /// Флаг удаленной сущности
        /// </summary>
        Boolean IsDeleted { set; get; }

        /// <summary>
        /// Дата и время создания сущности
        /// </summary>
        DateTime Created { set; get; }

        /// <summary>
        /// Дата и время обновления сущности
        /// </summary>
        DateTime? Updated { set; get; }
    }
}
