using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANGOCCONG.ANUIShop.API.Interfaces;
using TANGOCCONG.ANUIShop.API.Models;

namespace TANGOCCONG.ANUIShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : MyController
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _logger;

        public UsersController(IUserService userService, ILoggerManager logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogErr(string.Format("Đăng nhập không thành công với tài khoản {0}", request.UserName));
                return BadRequest(ModelState);
            }

            var result = await _userService.Authenticate(request);

            if (result != null && result.Error == 0 && !string.IsNullOrEmpty(result.Data.Token))
            {
                _logger.LogInfo(string.Format("Đăng nhập thành công với tài khoản {0}", result.Data.UserName));
                return Ok(result);
            }

            _logger.LogErr(string.Format("Đăng nhập không thành công: {0}", result.Msg));
            return BadRequest(result);
        }
    }
}
