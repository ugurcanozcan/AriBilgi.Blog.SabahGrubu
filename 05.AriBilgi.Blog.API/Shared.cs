using _02.AriBilgi.Blog.Model.UserDtos;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _05.AriBilgi.Blog.API
{
    public class Shared
    {
        public string SecretKey { get { return "UGURCANUGURCANUGURCANUGURCANUGURCANUGURCAN"; } }

        public string GenerateToken(UserDto userDto)
        {
            var claims = new[]
            {
                new Claim("Id",userDto.Id.ToString()),
                new Claim("Username",userDto.Username),
                new Claim("NameSurname",userDto.Name+" "+userDto.Surname)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var validations = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey))
            };

            var jwtSecurityToken = new JwtSecurityTokenHandler().ValidateToken(token, validations, out var tokenSource);
            return jwtSecurityToken;
        }

        public string GetNameSurname(string token)
        {
            ClaimsPrincipal jwtSecurityToken = DecodeToken(token);
            return jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "NameSurname").Value.ToString();

        }

        public string GetUsername(string token)
        {
            ClaimsPrincipal jwtSecurityToken = DecodeToken(token);
            return jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Username").Value.ToString();

        }

        public int GetId(string token)
        {
            ClaimsPrincipal jwtSecurityToken = DecodeToken(token);
            return Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        }
    }
}
