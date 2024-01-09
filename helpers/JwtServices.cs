using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Permissions;
using System.Text;

namespace WebApiOrder.helpers
{
    public class JwtServices : IJwtServices
    {

        public JwtServices()
        {
        }

        public string Generate(int userId)
        {
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constant.SECRET_KEY));
            var credentials = new SigningCredentials(symetricSecurityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(issuer: userId.ToString(), audience: null, notBefore: null, claims: null, expires: DateTime.Today.AddMinutes(30));

            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes (Constant.SECRET_KEY);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);
            return (JwtSecurityToken) validatedToken;
        }
    }
}
