using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Core.Interface
{
    public interface IUnitofWork
    {
        IUserRepo UserRepo { get; }
        void Save();
    }
}
