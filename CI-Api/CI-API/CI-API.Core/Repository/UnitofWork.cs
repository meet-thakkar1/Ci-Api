using CI_API.Models.Data;
using CI_API.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CI_API.Core.Repository
{
    public class UnitofWork:IUnitofWork
    {
        private CiApiContext _db;
        private IConfiguration _config;
        public UnitofWork(CiApiContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
            UserRepo = new UserRepo(_db, _config);
        }

        public IUserRepo UserRepo { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
