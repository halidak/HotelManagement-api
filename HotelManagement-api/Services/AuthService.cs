using AutoMapper;
using HotelManagement_api.DTOs;
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
        private readonly IMapper mapper;

        public AuthService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<bool> Register(RegisterDto user)
        {
            var u = await userManager.FindByNameAsync(user.UserName);
            if (u != null)
            {
                throw new Exception("User already exists");
            }

            User us = mapper.Map<User>(user);
            if (user.RoleId == 3)
            {
                us.Approved = true;
            }
            else
            {
                us.Approved = false;
            }
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
            if (!u.Approved)
            {
                throw new Exception("User is not approved");
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

        //approve employee
        public async Task<bool> ApproveEmployee(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            user.Approved = true;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("something went wrong");
            }
        }

        public async Task<bool> ChangePassword(string userId, ChangePasswordDto user)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            var result = await userManager.ChangePasswordAsync(u, user.OldPassword, user.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
