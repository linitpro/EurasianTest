using EurasianTest.Core.Components.DictionaryComponents.GetTasksDictionaryComponent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetHomeInfoModel.Model
{
    public class GetHomeInfoViewModel
    {
        public GetHomeInfoViewModel()
        {
            this.AdminInfo = null;
            this.TaskForWork = new List<TaskViewModel>();
            this.TasksStartOnNextWeek = new List<TaskViewModel>();
        }

        /// <summary>
        /// Занулять для обычного пользователя
        /// </summary>
        public GetHomeAdminInfoViewModel AdminInfo { set; get; }

        /// <summary>
        /// Задачи пользователя в работе
        /// </summary>
        public List<TaskViewModel> TaskForWork { set; get; }

        /// <summary>
        /// Список задач, которые будут начаты на следующей неделе
        /// </summary>
        public List<TaskViewModel> TasksStartOnNextWeek { set; get; }
    }
}
