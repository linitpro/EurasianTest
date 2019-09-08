using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AuthorizationComponent.Models
{
    public class AuthorizationViewModel
    {
        public AuthorizationViewModel() : this("", "", false)
        {
            
        }

        public AuthorizationViewModel(String login, String password, Boolean rememberMe)
        {
            this.login = login;
            this.password = password;
            this.RememberMe = rememberMe;
        }

        private String login;
        private String password;

        public String Login
        {
            set
            {
                this.login = value;
            }
            get
            {
                return this.login.Trim().ToLower();
            }
        }

        public String Password
        {
            set
            {
                this.password = value;
            }
            get
            {
                return this.password.Trim();
            }
        }

        public Boolean RememberMe { set; get; }
    }

    public class AuthorizationViewModelValidator: AbstractValidator<AuthorizationViewModel>
    {
        public AuthorizationViewModelValidator()
        {
            RuleFor(x => x.Login).EmailAddress().WithMessage("Должно содержать действительный адрес эл. почты");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Не может быть пустым");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Минимальная длина 6 символов");
        }
    }
}
