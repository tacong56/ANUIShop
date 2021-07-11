using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TANGOCCONG.ANUIShop.Data.Entities;

namespace TANGOCCONG.ANUIShop.API.Models
{
    public class AuthenticateModel
    {
    }

    #region: Request
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống.")]
        [MaxLength(50, ErrorMessage = "Được được quá 50 ký tự.")]
        [MinLength(4, ErrorMessage = "Phải có 4 ký tự.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [MaxLength(50, ErrorMessage = "Được được quá 50 ký tự.")]
        [MinLength(4, ErrorMessage = "Phải có 4 ký tự.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    #endregion

    #region: Response
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse() { }
        public AuthenticateResponse(AppUser user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Dob = user.Dob;
            PhoneNumber = user.PhoneNumber;
            Token = token;
        }
    }
    #endregion
}
