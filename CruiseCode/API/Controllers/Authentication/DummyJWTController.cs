using Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyJWTController : ControllerBase
    {
        private readonly AppConfig _appConfig;
        public DummyJWTController(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.IssuerSecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "dummyIssuer",
                audience: "dummyAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
