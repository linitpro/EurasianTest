using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.SelectionsDTOs
{
    public class GetHomeAdminInfoDTO
    {
        /// <summary>
        /// Завершено на текущей неделе
        /// </summary>
        public Int32 FinishedDateOnTheWeek { set; get; }

        /// <summary>
        /// Возвращено в работу на текущей неделе
        /// </summary>
        public Int32 ReturnedForWorkInTheWeek { set; get; }
    }
}
