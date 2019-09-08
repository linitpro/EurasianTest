using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateProjectComponent.Models
{
    public class UpdateProjectViewModel
    {
        public UpdateProjectViewModel()
        {
            this.name = "";
        }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Int64 Id { set; get; }

        private String name;

        /// <summary>
        /// Название проекта
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
    }

    public class UpdateProjectViewModelValidator : AbstractValidator<UpdateProjectViewModel>
    {
        public UpdateProjectViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Не может быть пустым");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Минимальная длина 3 символа");
        }
    }
}
