using CI_API.Application.services.services;
using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Application.services.Interface
{
    
    public interface IAuthorizeService:IGenericServices<User>
    {
        public User ValidateLoginUser(LoginVM login);
        public int RegisterUser(RegisterVm register);
        public string CreateJwt(User user, string role);
        public bool IsEmailRegistered(string email);
    }
}
