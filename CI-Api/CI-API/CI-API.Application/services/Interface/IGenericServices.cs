using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Application.services.Interface
{
    public interface IGenericServices<T> where T : class
    {
        public bool Test();
    }
}
