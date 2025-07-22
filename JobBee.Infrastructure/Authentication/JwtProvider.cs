using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobBee.Domain.Entities;
using JobBee.Application.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.AspNetCore.DataProtection;

namespace JobBee.Infrastructure.Authentication
{
	internal sealed class JwtProvider : IJwtProvider
	{
		private readonly JwtOptions _jwtOptions;

		public JwtProvider(IOptions<JwtOptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}

		public string Generate(User user)
		{
			var claims = new Claim[] {
				new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new(JwtRegisteredClaimNames.Email, user.Email.ToString()),
				new("role", string.Join(",", user.Roles.Select(x => x.Name)))
			};

			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
				SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _jwtOptions.Issuer,
				audience: _jwtOptions.Audience,
				claims: claims,
				null,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: signingCredentials);

			string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenValue;
		}
	}
}
