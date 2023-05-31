using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Core.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        
        public List<T> GetAll();

        public void Add(T entity);
    }
}
