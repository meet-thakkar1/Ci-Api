using CI_API.Application.services.Interface;
using CI_API.Application.services.services;
using CI_API.Common;
using CI_API.Core.Interface;
using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CI_API.Common.CommonMethods;
using  CI_API.Common.Static;
namespace CI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {

        private readonly IServiceWrapper _db;

        public AccessController(IServiceWrapper db)
        {
            _db = db;

        }

        [HttpGet("Test")]
        public JsonResult Test()
        {
            IEnumerable<User> u = _db.AuthorizeService.Test();
            _db.AuthorizeService.Test();
            return new JsonResult(u);
        }
        [HttpPost("Login")]
        public JsonResult Login([FromBody] LoginVM login)
        {
            if (login.Email == null || login.Password == null)
            {
                return new JsonResult(new ApiResponse<bool> { Data = false, Result = false, StatusCode = StatusCodeStat.Fail, Message = StatusCodeStat.FailMessage });
            }

            User u = _db.AuthorizeService.ValidateLoginUser(login);

            if (u == null)
            {
                return new JsonResult(new ApiResponse<bool> { Data = false, Result = false, StatusCode = StatusCodeStat.UnAuthorized, Message = StatusCodeStat.UnAuthorizedMessage });
            }

            string token = _db.AuthorizeService.CreateJwt(u, "User");

            return new JsonResult(new ApiResponse<string> { Data = token, Result = true, StatusCode = StatusCodeStat.Success, Message = StatusCodeStat.SuccessMessage });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVm register)
        {

            if (ModelState.IsValid)
            {
                int status = _db.AuthorizeService.RegisterUser(register);
                if (status == -1)
                {
                    return Ok(new JsonResult(new ApiResponse<bool> { Result = false, Data = false, Message = StatusCodeStat.UserExistsMessage, StatusCode = StatusCodeStat.UserExists }));
                }
                else
                {
                    return Ok(new JsonResult(new ApiResponse<bool> { Result = true, Data = true, Message = StatusCodeStat.SuccessMessage, StatusCode = StatusCodeStat.Success }));
                }

            }
            return BadRequest(new JsonResult(new ApiResponse<bool> { Result = false, Data = false, Message = StatusCodeStat.BadRequestMessage, StatusCode = StatusCodeStat.BadRequest }));

        }
        [HttpPost("ForgetPassword/{email}")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (email != null)
            {

                return Ok(_db.AuthorizeService.ForgotPassword(email));
            }
            return BadRequest();
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword reset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_db.AuthorizeService.ResetPassword(reset));
        }
    }
}
