using CI_API.Models.Data;
using CI_API.Core.Interface;
using CI_API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI_API.Models.ViewModels;


namespace CI_API.Core.Repository
{
    public class UserRepo: GenericRepository<User> ,IUserRepo
    {
        private readonly CiApiContext _db;
        public UserRepo(CiApiContext db) :base(db)
        {
            _db= db;    
        }

        public  User ValidateUser(LoginVM login)
        {
            User u=  _db.Users.Where(x=>x.Email==login.Email && x.Password==login.Password).FirstOrDefault();
            return u;
        }

        public bool IsEmailRegistered(string email)
        {
            User u=_db.Users.Where(user=>user.Email==email).FirstOrDefault();
            if (u != null) { return true; }
            return false;
        }
    }
}
