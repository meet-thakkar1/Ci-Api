using CI_API.Application.services.Interface;
using CI_API.Core.Interface;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        
        public ServiceWrapper(IUnitofWork db, IConfiguration config)
        {
            _db = db;
            _config = config;
            AuthorizeService = new AuthorizeService(db, _config);
        }
        public IAuthorizeService AuthorizeService { get; private set; }
    }
}
