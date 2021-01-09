using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JWTAuthentication.JWT
{
    /// <summary>
    /// In the example, I only add a username claim, but the list of claim types that can be added is huge. 
    /// t is also possible to add custom data to the token after you created it by accessing the Payload property.
    /// </summary>
    public class TokenManager
    {
        // generate a secret key
        private static HMACSHA256 hmac = new HMACSHA256();
        private static string key = Convert.ToBase64String(hmac.Key);

        // pre made secret key
        private static string Secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GenerateToken(string username)
        {
            // decoding the key(Secret)
            byte[] key = Convert.FromBase64String(Secret);
            //create a SymmetricSecurityKey object and passing the key(Secret)
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            // creating the descriptor object
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                // creating claims
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, username)}),
                // the expiration date 
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            // creating a handler
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            // the token is created 
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            // a string version of the token is returned
            return handler.WriteToken(token);
        }
    }
}