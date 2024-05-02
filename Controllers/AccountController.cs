using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day2.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost]
		public IActionResult Login([FromBody]LoginModel loginModel)
		{
			if (loginModel.Email == "esraa@gmail.com" && loginModel.Password == "123456")
			{
				List<Claim> userData = new List<Claim>();
				userData.Add(new Claim(ClaimValueTypes.Email, loginModel.Email));
				userData.Add(new Claim("email", "esraa@gmail.com"));
				userData.Add(new Claim("password", "123456"));
				userData.Add(new Claim(ClaimTypes.Role, "admin"));

				var secretKey = "This is my secret keyyyyyyyyyyyyyyy";
				var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
				var HashingSecretKey = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

				var token = new JwtSecurityToken(
					claims: userData,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: HashingSecretKey
					);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
				return Ok(tokenString);
			}
			return Unauthorized();
		}
		public class LoginModel
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}
	}
}
