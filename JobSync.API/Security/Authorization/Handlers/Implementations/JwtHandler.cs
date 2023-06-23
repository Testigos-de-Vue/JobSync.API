﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobSync.API.Security.Authorization.Handlers.Interfaces;
using JobSync.API.Security.Authorization.Settings;
using JobSync.API.Security.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobSync.API.Security.Authorization.Handlers.Implementations;

public class JwtHandler : IJwtHandler
{
  private readonly AppSettings _appSettings;


  public JwtHandler(IOptions<AppSettings> appSettings)
  {
    _appSettings = appSettings.Value;
  }

  public string GenerateToken(User user)
  {
    var secret = _appSettings.Secret;
    var key = Encoding.ASCII.GetBytes(secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.Sid, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Email),
      }),
            
      Expires = DateTime.UtcNow.AddDays(31),

      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(key),
        SecurityAlgorithms.HmacSha512Signature
      )
    };
    
    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    
    return tokenHandler.WriteToken(token);
  }

  public int? ValidateToken(string token)
  {
    if (string.IsNullOrEmpty(token)) return null;

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    
    try
    {
      tokenHandler.ValidateToken(token, new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
      }, out var validatedToken);
      
      var jwtToken = (JwtSecurityToken) validatedToken;
      var userId = int.Parse(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
      
      return userId;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      return null;
    }
  }
}