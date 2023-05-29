using CI_API.Core.Interface;
using CI_API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Application.services.services
{
    public class GenericServices<T> where T : class
    {
        private readonly IUnitofWork _db;
        public GenericServices(IUnitofWork db)
        {
            _db= db;
        }
        public bool Test()
        {
            List<User> u = _db.UserRepo.GetAll();
            return true;
        }
    }
}
