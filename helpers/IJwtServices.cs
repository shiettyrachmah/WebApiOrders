using System.IdentityModel.Tokens.Jwt;

namespace WebApiOrder.helpers
{
    public interface IJwtServices
    {
        public string Generate(int userId);

        public JwtSecurityToken Verify(string jwt);
    }
}
