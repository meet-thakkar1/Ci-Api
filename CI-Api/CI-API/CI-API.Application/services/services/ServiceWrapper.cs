using CI_API.Application.services.Interface;
using CI_API.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Application.services.services
{
    public class ServiceWrapper:IServiceWrapper
    {
        private readonly IUnitofWork _db;
        
        public ServiceWrapper(IUnitofWork db)
        {
            _db = db;
            AuthorizeService = new AuthorizeService(db);
        }
        public IAuthorizeService AuthorizeService { get; private set; }
    }
}
