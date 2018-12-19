using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface IRepository<T>where T:class
    {
        void Delete(int id);
        void Create(T item);
        void Update(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T,bool> preficate);
    }
}
