using CI_API.Application.services.Interface;
using CI_API.Core.Interface;
using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CI_API.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CI_API.Application.services.services
{
    public class AuthorizeService: GenericServices<User>,IAuthorizeService
    {
        private readonly IUnitofWork _db;
        private readonly IConfiguration _config;
        public AuthorizeService(IUnitofWork db, IConfiguration config) :base(db)
        {
            _db = db;
            _config = config;
        }

        public IEnumerable<User> Test()
        {

            CommonMethods m=new CommonMethods(_config);
            IEnumerable<User> u=_db.UserRepo.TestRepo();
            return u;
            
        }

        public User ValidateLoginUser(LoginVM login)
        {
            return _db.UserRepo.ValidateUser(login);
         
        }

        public int RegisterUser(RegisterVm register)
        {
            bool isRegister = IsEmailRegistered(register.Email);
            if (isRegister)
            {
                return -1; //User Already Exists
            }
            User user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = (int)register.Phone,
                Password=register.Password,
                Email = register.Email,
            };
            
            _db.UserRepo.Add(user);
            _db.Save();
            if(user != null)
            {
                return 1;
            }
            return 0;
        }

        //public bool Is User
        public string CreateJwt(User user, string role)
        {
            var jwt = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("cisecretthisis..");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.Sid,user.UserId.ToString()),
               
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = credentials,
            };
            var token = jwt.CreateToken(tokenDescriptor);
            return jwt.WriteToken(token);

        }

        public bool IsEmailRegistered(string email)
        {
           bool b= _db.UserRepo.IsEmailRegistered(email);
           return b;
        }

        public IActionResult ForgotPassword(string email)
        {
            JsonResult j=(JsonResult)_db.UserRepo.ForgotPassword(email);
            return j;
        }

        public IActionResult ResetPassword(ResetPassword reset)
        {
            return _db.UserRepo.ResetPassword(reset);
        }
    }
}
