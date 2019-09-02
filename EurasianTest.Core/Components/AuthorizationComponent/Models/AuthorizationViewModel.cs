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
}
