using CI_API.Application.services.Interface;
using CI_API.Application.services.services;
using CI_API.Common;
using CI_API.Core.Interface;
using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CI_API.Common.StatusCodeStat;
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
        [Authorize]
        [HttpGet("Test")]
        public JsonResult Test()
        {
            
            _db.AuthorizeService.Test();
            return new JsonResult("abc");
        }
        [HttpPost("Login")]
        public JsonResult Login([FromBody] LoginVM login)
        {
            if (login.Email == null || login.Password == null)
            {
                return new JsonResult(new ApiResponse<bool> { data = false, result=false,statusCode=StatusCodeStat.fail,message=StatusCodeStat.failMessage });
            }
            
            User u= _db.AuthorizeService.ValidateLoginUser(login);

            if (u==null)
            {
                return new JsonResult(new ApiResponse<bool> { data = false, result = false, statusCode = StatusCodeStat.unAuthorized, message = StatusCodeStat.unAuthorizedMessage });
            }

            string token=_db.AuthorizeService.CreateJwt(u, "User");

            return new JsonResult(new ApiResponse<string> { data = token, result = true, statusCode = StatusCodeStat.success, message = StatusCodeStat.successMessage });
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterVm register)
        {
            if (ModelState.IsValid)
            {

                return Ok();
            }
            return BadRequest();
            
        }
    }
}
