using Periferia.API._3._Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.API._2._Managers.Interfaces
{
    public interface ISimpleSaleMAnager
    {
        public  Task<SimpleSale> SetItem(SimpleSale item);
        public Task<List<SimpleSale>> GetItems(string param);
    }
}
