﻿using HotelManagement_api.DTOs;
using HotelManagement_data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagement_api.Services
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        public AuthService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> Register(RegisterDto user)
        {
            var u = await userManager.FindByNameAsync(user.UserName);
            if (u != null)
            {
                throw new Exception("User already exists");
            }
            User us = new User
            {
                UserName = user.UserName,
                Email = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId
            };
            var result = await userManager.CreateAsync(us, user.Password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<object> Login(LoginDto user)
        {
            var u = await userManager.FindByNameAsync(user.UserName);
            if (u == null)
            {
                throw new Exception("User do not exists");
            }

            if (await userManager.CheckPasswordAsync(u, user.Password))
            {
                var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq"));
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
                    );
                var toReturn = new JwtSecurityTokenHandler().WriteToken(token);
                var obj = new
                {
                    expires = DateTime.Now.AddHours(2),
                    token = toReturn,
                    user = u
                };
                return obj;
            }
            else
            {
                throw new Exception("Username and password not match");
            }
        }
    }
}
