﻿using Api.Controllers;
using Api.Helpers;
using Api.Models;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;


[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : AuthorizedCSABaseAPIController
{
    
    private readonly IConfiguration _configuration;
    public AuthController(IUserService userService,ILogger<AuthController> logger,IConfiguration configuration)
        :base(userService,logger)
    {
        _configuration = configuration;
    }


    [AllowAnonymous]
    [HttpPost()]
    public async  Task<ActionResult <CSAResponseModel<AuthenticationResponse>>>Authenticate([FromBody] AuthenticationModel model)
    {
        try
        {
            string clientIp = NetWorkUtils.GetClientIp(HttpContext);
            var user = _userService.Authenticate(model.Username, model.Password,model.RoleId, out AuthenticationError loginError);
            if (user == null || !await _userService.CheckPassword(model.Username,model.Password,model.RoleId))
            {
                _logger.Log(LogLevel.Debug, "Login Failed");
                _userService.LogAuthAttempt(model.Username, clientIp, loginError.Message, null, false);
                if (loginError.Reason == AuthenticationErrorReason.UserDeactivated)
                {
                    return Unauthorized(new ErrorMessage { message = "Login failed" });
                }
                return BadRequest(new ErrorMessage { message = "Login failed" });
            }

            var Role = _userService.RoleForUser(user.Id);
            string tokenString = GenerateJwtToken(user, clientIp);

            var authResponse = new AuthenticationResponse { Token = tokenString, RedirectTo = "/dashboard" };
            return new CSAResponseModel<AuthenticationResponse>(authResponse);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    private string GenerateJwtToken(IUser user, string ip)
    {
        List<Claim> claims = CreateClaims(ip, user);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience= _configuration["JwtSettings:Audience"],
            Issuer = _configuration["JwtSettings:Issuer"],
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiryMinutes"])),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        _userService.LogAuthAttempt(user.Details.UserName, ip, "Ok", tokenDescriptor.Expires, true);
        return tokenString;
    }


    private List<Claim> CreateClaims(string ip, IUser user)
    {
        if (user.Details == null)
        {
            throw new ApplicationException("User Details Can't be null");
        }
        var claims = new List<Claim>()
        {
            new("userid",user.Id.ToString()),
            new("roleid",user.Details.RoleId.ToString()),
            new(ClaimTypes.Name,user.Details.UserName),
            new("CommunityId",user.Details.CommunityId.ToString()),
            new("FirstName",user.Details.FirstName),
            new("LastName",user.Details.LastName),
            new(ClaimTypes.Role,user.Role),
           
        };
        return claims;
    }


    [AllowAnonymous]
    [HttpPost()]
    public async Task<ActionResult<CSAResponseModel<AuthenticationResponse>>> ResidentAuthenticate([FromBody] AuthenticationModel model)
    {
        try
        {
            string clientIp = NetWorkUtils.GetClientIp(HttpContext);
            var user = _userService.Authenticate(model.Username, model.Password,model.RoleId, out AuthenticationError loginError);
            if (user == null || !await _userService.CheckPassword(model.Username, model.Password,model.RoleId))
            {
                _logger.Log(LogLevel.Debug, "Login Failed");
                _userService.LogAuthAttempt(model.Username, clientIp, loginError.Message, null, false);
                if (loginError.Reason == AuthenticationErrorReason.UserDeactivated)
                {
                    return Unauthorized(new ErrorMessage { message = "Login failed" });
                }
                return BadRequest(new ErrorMessage { message = "Login failed" });
            }

            //var Role = _userService.RoleForUser(user.Id)==""?model.RoleId.ToString(): _userService.RoleForUser(user.Id);
            var existingRole = _userService.RoleForUser(user.Id);
            var Role = string.IsNullOrWhiteSpace(existingRole) ? model.RoleId.ToString() : existingRole;
            string tokenString = GenerateJwtToken(user, clientIp);

            var authResponse = new AuthenticationResponse { Token = tokenString, RedirectTo = "/home" };
            return new CSAResponseModel<AuthenticationResponse>(authResponse);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

   
}

