using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace MySingingBird.Core.Security
{
    public class SigningHelper : ISigningHelper
    {
        public string SignKey(string signingKey)
        {
            var hasher = new HMACSHA1(
                new ASCIIEncoding().GetBytes(signingKey));

            string signatureString = Convert.ToBase64String(
                hasher.ComputeHash(
                    new ASCIIEncoding().GetBytes(signingKey)));

            ServicePointManager.Expect100Continue = false;

            return signatureString;
        }
    }
}