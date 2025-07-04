using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services.Implementation;

public class TokenService(IConfiguration config) : ITokenService
{
    public String GenerateToken(User user)
    {
        // Fetching the token from the appsettings.json
        var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot Access the token key");

        // Validating the length of the token key
        if (tokenKey.Length < 64) throw new Exception("The token key is less than 64 characters");

        // Creating the JWT (JSON web token)
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        // Setting up thw algorthim to encrypt the token
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        // creating the claims
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName)
        };

        // creating a token description
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddYears(1),
            SigningCredentials = creds
        };

        // Creating a token handler
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // writing the token and returing it        
        return tokenHandler.WriteToken(token);

    }
}
