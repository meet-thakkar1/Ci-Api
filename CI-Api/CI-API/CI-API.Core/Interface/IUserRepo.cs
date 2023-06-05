using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Core.Interface
{
    public interface IUserRepo:IGenericRepository<User>
    {
        public IEnumerable<User> TestRepo();
        public User ValidateUser(LoginVM login);
        public bool IsEmailRegistered(string email);
        public IActionResult ForgotPassword(string email);
        public IActionResult ResetPassword(ResetPassword reset);
    }
}
