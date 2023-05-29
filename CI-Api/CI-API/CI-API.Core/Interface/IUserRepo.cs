using CI_API.Models.Models;
using CI_API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Core.Interface
{
    public interface IUserRepo:IGenericRepository<User>
    {
        public User ValidateUser(LoginVM login);
    }
}
