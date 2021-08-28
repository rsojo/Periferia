using Periferia.MVC.Helpers;
using Periferia.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Services.Interfaces
{
    public interface ISimpleSaleService
    {
        public Task<Response<SimpleSale>> SetItem(SimpleSale item);
        public Task<Response<SimpleSale>> GetItems(string param);
    }
}
