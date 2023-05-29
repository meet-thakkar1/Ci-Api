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

namespace CI_API.Application.services.services
{
    public class AuthorizeService: GenericServices<User>,IAuthorizeService
    {
        private readonly IUnitofWork _db;
        public AuthorizeService(IUnitofWork db) :base(db)
        {
            _db = db;
        }

        public User ValidateLoginUser(LoginVM login)
        {
            return _db.UserRepo.ValidateUser(login);
         
        }

        public int RegisterUser(RegisterVm register)
        {
            User user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = int.Parse(register.PhoneNumber),
                Password=register.Password,
                Email = register.Email,
            };
            
            _db.UserRepo.Add(user);
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
                new Claim("Avatar",user.Avatar)
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

    }
}
