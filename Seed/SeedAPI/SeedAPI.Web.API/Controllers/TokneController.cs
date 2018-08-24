using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SeedAPI.ViewModels;

namespace SeedAPI.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokneController : Controller
    {
        private IConfiguration _configuration;

        public TokneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public dynamic Post([FromBody] LoginViewModel loginViewModel)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(loginViewModel);

            if (user != null)
            {
                var tokenString = BuildToken(user);

                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private object BuildToken(UserViewModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserViewModel Authenticate(LoginViewModel loginViewModel)
        {
            UserViewModel user = null;

            if (loginViewModel.username == "pablo" && loginViewModel.password == "secret")

            {
                user = new UserViewModel { name = "Pablo" };
            }

            return user;
        }
    }
}