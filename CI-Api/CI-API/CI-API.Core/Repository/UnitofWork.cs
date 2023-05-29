using CI_API.Models.Data;
using CI_API.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Core.Repository
{
    public class UnitofWork:IUnitofWork
    {
        private CiplatformContext _db;
        public UnitofWork(CiplatformContext db)
        {
            _db = db;
            UserRepo = new UserRepo(_db);
        }

        public IUserRepo UserRepo { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
