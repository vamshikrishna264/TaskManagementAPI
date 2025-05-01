using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config) // injecting the configuration services for Login

        { 
            _config = config;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login) 
        {
            if(login.Username=="Admin" && login.Password=="admin")  
            {
                var token = GenerateJwtToken(login.Username, "Admin");//accesing the token method when admin loggedin

                return Ok(new { token });


            }

            else if (login.Username == "user" && login.Password == "user")
            {
                var token = GenerateJwtToken(login.Username, "User");//accesing the token method when user is loggedin
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(string username, string role)// this method is for token generation
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),// using claims we are deciding the types and values
                new Claim(ClaimTypes.Role, role),//assinging the roles 
           };

            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
    }


 


