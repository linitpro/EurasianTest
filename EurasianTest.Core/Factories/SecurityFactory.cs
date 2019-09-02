using EurasianTest.Core.Constants;
using EurasianTest.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Factories
{
    public static class SecurityFactory
    {
        private static Random random = new Random();

        public static (String Salt, String HashedPassword) CreateCredetial(String password)
        {
            var salt = random.Next(100000, 999999).ToString(); // TODO можно сделать посложнее
            var hashedPassword = HashPassword(password, salt);
            return (salt, hashedPassword);
        }

        public static String HashPassword(String password, String salt)
        {
            return CryptoHelper.GenerateBase64Hash(CryptoHelper.GenerateBase64Hash(password) + salt + Security.PASSWORDSALT);
        }
    }
}
