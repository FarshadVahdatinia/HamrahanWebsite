using FarshadTools;
using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HamrahanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;
        private readonly IUow _uow;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Person> userManager, SignInManager<Person> signInManager,IUow uow,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
            _configuration = configuration;
           
        }

        // POST api/<AuthController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Post([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model Is Not Valid");
            }
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user==null )
            {
                return NotFound(login);
            }
           
            var signinResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!signinResult.Succeeded)
            {
                return Conflict("نام کابری یا رمز عبور اشتباه است!!");

            }
            var claims = await _signInManager.ClaimsFactory.CreateAsync(user);
            var Token = TokenGenerator.GetToken( claims.Claims, _configuration);
            return Ok(Token);
        }

  
    }
}



// var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Key").Value));

// var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

// var tokenOption = new JwtSecurityToken(
//     issuer: "https://localhost:44396",
//     claims: new List<Claim>
//     {
//         new Claim(ClaimTypes.Name,login.Email),
//         new Claim(ClaimTypes.Role,"Admin")
//     },
//     expires: DateTime.Now.AddMinutes(30),
//     signingCredentials: signinCredentials
// );
// var tokenString = "";
//await Task.Run(() => {
//      tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);


// });