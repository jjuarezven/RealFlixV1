using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text;
using RealFlix.Models;
using System.Collections.Generic;
using System;

namespace RealFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUserModel> signInManager;
        private readonly UserManager<IdentityUserModel> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUserModel> _userManager, SignInManager<IdentityUserModel> _signInManager, IConfiguration _configuration)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            configuration = _configuration;
        }

		[HttpPost]
		[Route("login")]
		public async Task<object> Login([FromBody] LoginModel model)
		{
			bool enableLockout = false;
			var user = await userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, enableLockout);
				if (result.Succeeded)
				{
					return await generateJwtToken(model.Email, user);
				}
			}
			var response = new
			{
				success = false,
				errorMessage = "Login failed"
			};
			return Ok(response);
		}

		[NonAction]
		private async Task<object> generateJwtToken(string email, IdentityUserModel user)
		{
			var roles = await userManager.GetRolesAsync(user);
			var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(ClaimTypes.NameIdentifier, user.Id),
			new Claim(ClaimTypes.Role, roles[0])
		};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.UtcNow.AddHours(Convert.ToDouble(configuration["JwtExpireHours"]));
			var token = new JwtSecurityToken(configuration["JwtIssuer"],
											configuration["JwtAudience"],
											claims,
											expires: expires,
											signingCredentials: creds
											);
			var response = new
			{
				auth_token = new JwtSecurityTokenHandler().WriteToken(token),
				success = true
			};
			return Ok(response);
		}
	}
}