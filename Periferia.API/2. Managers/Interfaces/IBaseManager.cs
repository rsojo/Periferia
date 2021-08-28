using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.API._2._Managers.Interfaces
{
    public interface IBaseManager<T> where T : new()
    {

        public  Task<T> GetItem(Int64 id);
        public  Task<List<T>> GetItems(string param);
        public  Task<T> SetItem(T item);
        public  Task<int> Delete(Int64 id);
    }
}
