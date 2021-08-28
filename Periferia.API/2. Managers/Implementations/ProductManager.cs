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
    public class ProductManager : IProductManager
    {
        private readonly PeriferiDBContext _context;

        public ProductManager(PeriferiDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return -1;
            }
            _context.Products.Remove(product);
            var t = await _context.SaveChangesAsync();
            return t;
        }

        public async Task<Product> GetItem(long id)
        {
            return _context.Products
                .FirstOrDefault(m => m.Id == id);
        }

        public async Task<List<Product>> GetItems(string param)
        {
            param = param ?? "";
            return _context.Products.Where(x => (x.Name.Contains(param))).ToList();
        }

        public async Task<Product> SetItem(Product item)
        {
            _context.Entry(item).State = item.Id == 0 ?
            EntityState.Added :
            EntityState.Modified;

            _context.SaveChanges();
            var response = await _context.SaveChangesAsync();

            var result = new Product();
            if (response != 0)
            {

                result = _context.Products
                   .FirstOrDefault(m => m.Id == item.Id);

            }

            return result;
        }
    }
}
