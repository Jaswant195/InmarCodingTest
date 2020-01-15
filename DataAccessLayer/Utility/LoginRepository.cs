using DataAccessLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utility
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<object> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (loginViewModel != null && loginViewModel.UserName == "Jaswant" && loginViewModel.Password == "1234@asd")
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, loginViewModel.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKeyforToken"));
                    var token = new JwtSecurityToken
                        (
                        issuer: "http://abc.com",
                        audience: "http://abc.com",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));

                    var result = new { access_token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo };
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
