using QSpace.Core.Dtos;
using QSpace.Core.Exceptions;
using QSpace.Core.ViewModels;
using QSpace.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using QSpace.Data.Data;
using AutoMapper;
using QSpace.Data.DbEntities;
using Microsoft.Extensions.Configuration;

namespace QSpace.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _Mapper;
        private readonly QSpaceDbContext _DB;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _Configuration;
        private readonly UserManager<User> _userManager;

        public AuthService(QSpaceDbContext DB, SignInManager<User> signInManager, IMapper Mapper, IConfiguration Configuration, UserManager<User> userManager)
        {
            _DB = DB;
            _signInManager = signInManager;
            _Mapper = Mapper;
            _Configuration = Configuration;
            _userManager = userManager;
        }


        public async Task SaveFcmToken(string fcm,string userId)
        {
            var user = await _DB.Users.SingleOrDefaultAsync(x => x.Id == userId && !x.IsDelete);
            user.FCMToken = fcm;
            _DB.Users.Update(user);
            await _DB.SaveChangesAsync();
        }

        public async Task<LoginResponseViewModel> LoginAsync(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDelete);

            if (user == null)
            {
                throw new InvalidUsernameException();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (result.Succeeded)
            {
                // We can check here if the user is active
                user.FCMToken = dto.FCM;

                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = await GenerateAccessToken(user);
                var response = new LoginResponseViewModel();
                response.Token = token;
                response.User = _Mapper.Map<UserViewModel>(user);
                //response.User = new UserViewModel()
                //{
                //    Id = user.Id,
                //    Name = user.Name,
                //    Email = user.Email,
                //    PhoneNumber = user.PhoneNumber,
                //    UpdatedAt = user.UpdatedAt,
                //    FCMToken = user.FCMToken
                //};
                //var uservm = _Mapper.Map<UserViewModel>(user);
                return response;
            }
            throw new InvalidUsernameException();
        }
        private async Task<TokenViewModel> GenerateAccessToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim("UserId", user.Id),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };
            if (roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }
            var expires = DateTime.Now.AddMonths(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:SigningKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var accessToken = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                _Configuration["Jwt:Site"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var response = new TokenViewModel();
            response.AcessToken = AccessToken;
            response.ExpireAt = expires;
            return response;
        }

        public async Task<bool> ChangePassword(string userId, ChangePasswordDto dto) {
            var user = _DB.Users.Find(userId);
            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            return result.Succeeded;
        }
    }
}
