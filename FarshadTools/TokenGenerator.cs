using Hamrahan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarshadTools
{
   public class TokenGenerator
    {


       

        public static string GetToken(IEnumerable<Claim> claims,IConfiguration configuration)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Key").Value));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            ///For Encrypting Payload
            var encrytionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Key").Value));
            var encriptionCredential = new EncryptingCredentials(encrytionKey,
                                                               SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor() {
                Issuer = "https://localhost:44396",
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signinCredentials,
                EncryptingCredentials = encriptionCredential,
                CompressionAlgorithm= CompressionAlgorithms.Deflate,
                Expires=DateTime.Now.AddMinutes(5)
               
                
            };
      

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}




//var tokenOption = new JwtSecurityToken(
//  issuer: "https://localhost:44396",
//  claims: claims,
//{     new Claim(ClaimTypes.NameIdentifier, person.UserName),
//      new Claim(ClaimTypes.Name,person.FullName),
//      new Claim(ClaimTypes.Role,RoleManager)
//},

//  expires: DateTime.Now.AddMinutes(30),
//  signingCredentials: signinCredentials,
//  CompressionAlgorithms:CompressionAlgorithms.Deflate
//);
