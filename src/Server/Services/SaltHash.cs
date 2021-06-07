﻿

namespace MainAPI.Services
{
    public class SecurityHelper
    {
        public static string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return System.Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = System.Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return System.Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}