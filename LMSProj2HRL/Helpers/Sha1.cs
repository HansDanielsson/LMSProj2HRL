using System;

namespace LMSProj2HRL.Helpers
{
    public class Sha1
    {
        /// <summary>
        /// Kodar lösenordet till Sha1 algoritm
        /// </summary>
        /// <param name="value">Lösenordet</param>
        /// <returns>Sha1 kodning</returns>
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}