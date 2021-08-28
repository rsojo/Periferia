using Periferia.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Services.Interfaces
{
    public interface IBaseService<T> where T : new()
    {

        public Task<Response<T>> GetItem(Int64 id);
        public Task<Response<T>> GetItems(string param);
        public Task<Response<T>> SetItem(T item);
        public Task<Response<int>> Delete(Int64 id);
    }
}
