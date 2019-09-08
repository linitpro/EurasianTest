using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddProjectComponent.Model
{
    public class AddProjectViewModel
    {
        public AddProjectViewModel()
        {
            this.name = "";
        }

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
    }

    public class AddProjectViewModelValidator : AbstractValidator<AddProjectViewModel>
    {
        public AddProjectViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Не может быть пустым");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Минимальная длина 3 символа");
        }
    }
}
