using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EurasianTest.Core.Helpers
{
    public static class CryptoHelper
    {
        private static SHA256 sha256 = new SHA256CryptoServiceProvider();

        public static string GenerateBase64Hash(string sourceText)
        {
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(sourceText)));
        }
    }
}
