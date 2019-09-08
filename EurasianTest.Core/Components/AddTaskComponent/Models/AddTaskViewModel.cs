using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent.Models
{
    public class AddTaskViewModel
    {
        public AddTaskViewModel(): this(new List<UserViewModel>()) {}

        public AddTaskViewModel(List<UserViewModel> users)
        {
            this.Description = "";
            this.Name = "";
            this.Users = users;
            this.Started = DateTime.Now.ToShortDateString();
            this.Expired = DateTime.Now.ToShortDateString();
        }

        private String description;

        /// <summary>
        /// Описание задачи
        /// </summary>
        public String Description
        {
            set
            {
                this.description = value;
            }
            get
            {
                return this.description?.Trim() ?? "";
            }
        }

        private String name;

        /// <summary>
        /// Название задачи
        /// </summary>
        public String Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name?.Trim() ?? "";
            }
        }

        /// <summary>
        /// Проект к которому добавляется задача
        /// </summary>
        public Int64 ProjectId { set; get; }

        /// <summary>
        /// Проект
        /// </summary>
        public String ProjectName { set; get; }

        /// <summary>
        /// Пользователь, для которого назначается задача
        /// </summary>
        public Int64 UserId { set; get; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public List<UserViewModel> Users { set; get; }

        /// <summary>
        /// 
        /// </summary>
        private String started;

        /// <summary>
        /// Дата начала задачи
        /// </summary>
        public String Started
        {
            set
            {
                this.started = value;
            }
            get
            {
                return this.started?.Trim() ?? "";
            }
        }

        public DateTime GetStarted()
        {
            return DateTime.Parse(this.started);
        }

        private String expired;

        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public String Expired
        {
            set
            {
                this.expired = value;
            }
            get
            {
                return this.expired?.Trim() ?? "";
            }
        }

        public DateTime GetExpired()
        {
            return DateTime.Parse(this.expired);
        }
    }

    public class AddTaskViewModelValidator : AbstractValidator<AddTaskViewModel>
    {
        public AddTaskViewModelValidator()
        {
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
            RuleFor(x => x.Expired).Custom((item, context) =>
            {
                if(!DateTime.TryParse(item, out DateTime dateTime))
                {
                    context.AddFailure("Невалидная дата");
                }
            });
            RuleFor(x => x.Started).Custom((item, context) =>
            {
                if (!DateTime.TryParse(item, out DateTime dateTime))
                {
                    context.AddFailure("Невалидная дата");
                }
            });
        }
    }
}
