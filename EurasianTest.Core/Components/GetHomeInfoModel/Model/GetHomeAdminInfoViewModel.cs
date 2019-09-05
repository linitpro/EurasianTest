using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetHomeInfoModel.Model
{
    public class GetHomeAdminInfoViewModel
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
