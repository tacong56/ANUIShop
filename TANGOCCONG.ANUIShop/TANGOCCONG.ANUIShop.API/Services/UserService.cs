using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TANGOCCONG.ANUIShop.API.Helpers;
using TANGOCCONG.ANUIShop.API.Interfaces;
using TANGOCCONG.ANUIShop.API.Models;
using TANGOCCONG.ANUIShop.API.Objects;
using TANGOCCONG.ANUIShop.Data.Entities;

namespace TANGOCCONG.ANUIShop.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings, UserManager<AppUser> userManager,
             SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
        }
        public async Task<ResponseData<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var login = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if (user == null)
                return new ErrorResponseData<AuthenticateResponse>("Tài khoản không tồn tại.");

            if (!login.Succeeded)
                return new ErrorResponseData<AuthenticateResponse>("Tài khoản hoặc mật khẩu không chính xác.");

            // authentication successful so generate jwt token
            string token = generateJwtToken(user);
            var resData = new AuthenticateResponse(user, token);

            return new SuccessResponseData<AuthenticateResponse>("", resData); ;
        }

        public Task<IEnumerable<AppUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<AuthenticateResponse>> GetById(GetDetailRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null)
                return new ErrorResponseData<AuthenticateResponse>("Tài khoản không tồn tại.");

            var resData = new AuthenticateResponse()
            {
                Id = user.Id,
                Dob = user.Dob,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };

            return new SuccessResponseData<AuthenticateResponse>("", resData);
        }

        private string generateJwtToken(AppUser user)
        {
            // generate token that is valid for 1 hours
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
