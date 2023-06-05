using CI_API.Application.services.services;
using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Application.services.Interface
{
    
    public interface IAuthorizeService:IGenericServices<User>
    {
        public IEnumerable<User> Test();
        public User ValidateLoginUser(LoginVM login);
        public int RegisterUser(RegisterVm register);
        public string CreateJwt(User user, string role);
        public bool IsEmailRegistered(string email);
        public IActionResult ForgotPassword(string email);
        public IActionResult ResetPassword(ResetPassword reset);
    }
}
