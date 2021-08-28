using Microsoft.EntityFrameworkCore;
using Periferia.API._2._Managers.Interfaces;
using Periferia.API._3._Data.Entities;
using Periferia.API._3._Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.API._2._Managers.Implementations
{
    public class SimpleSaleManager : ISimpleSaleMAnager
    {
        private readonly PeriferiDBContext _context;

        public SimpleSaleManager(PeriferiDBContext context)
        {
            _context = context;
        }
        public async Task<SimpleSale> SetItem(SimpleSale item)
        {
            _context.Entry(item).State = item.Id == 0 ?
               EntityState.Added :
               EntityState.Modified;

            var prod = _context.Products.Find(item.ProductId);
            item.UnitValue = prod.UnitValue;
            item.TotalValue = prod.UnitValue * item.Count;

            _context.SaveChanges();
            var response = await _context.SaveChangesAsync();

            var result = new SimpleSale();
            if (response != 0)
            {

                result = _context.SimpleSales
                   .FirstOrDefault(m => m.Id == item.Id);

            }

            return result;
        }



        public async Task<List<SimpleSale>> GetItems(string param)
        {
            param = param ?? "";
            var t = _context.SimpleSales.Include(p => p.Product).Include(c =>c.Client).ToList();

            return t;
        }
    }
}
