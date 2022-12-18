using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T Add(T item);
        public T Update(T item);
        public bool Remove(T item);
    }
}
