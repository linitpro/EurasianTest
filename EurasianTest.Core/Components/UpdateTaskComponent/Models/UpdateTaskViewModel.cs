using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateTaskComponent.Models
{
    public class UpdateTaskViewModel
    {
        public UpdateTaskViewModel()
        {
            this.Name = "";
            this.Description = "";
        }

        public Int64 Id { set; get; }

        private String name;

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

        private String description;

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

    public class UpdateTaskViewModelValidator : AbstractValidator<UpdateTaskViewModel>
    {
        public UpdateTaskViewModelValidator()
        {
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
            RuleFor(x => x.Expired).Custom((item, context) =>
            {
                if (!DateTime.TryParse(item, out DateTime dateTime))
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
