using Microsoft.IdentityModel.Tokens;
using silverhorse.Business_Logic;
using System.Security.Claims;

namespace silverhorse.Dtos
{
    public class CustomSecurityToken : SecurityToken
    {
        public ClaimsPrincipal Principal { get; }

        public CustomSecurityToken(ClaimsPrincipal principal)
        {
            Principal = principal;
            ValidFrom = DateTime.UtcNow;
            ValidTo = DateTime.UtcNow.AddHours(1);
        }

        public override string Id => Guid.NewGuid().ToString();
        public override string Issuer => string.Empty;
        public override SecurityKey SecurityKey => null;
        public override SecurityKey SigningKey { get; set; }
        public override DateTime ValidFrom { get; }
        public override DateTime ValidTo { get; }
    }

}
