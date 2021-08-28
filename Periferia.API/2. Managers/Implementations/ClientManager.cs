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
    public class ClientManager : IClientManager
    {
        private readonly PeriferiDBContext _context;

        public ClientManager(PeriferiDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(long id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return -1;
            }

            _context.Clients.Remove(client);
            return await _context.SaveChangesAsync();
        }

        public async Task<Client> GetItem(long id)
        {
            return _context.Clients
                .FirstOrDefault(m => m.Id == id);
        }

        public async Task<List<Client>> GetItems(string param)
        {
            param = param ?? "";
            var t = _context.Clients.Where(x => (x.DocNumber.Contains(param) || x.FirstName.Contains(param) || x.LastName.Contains(param))).ToList();

            return  t;
         }

        public async Task<Client> SetItem(Client item)
        {
            _context.Entry(item).State = item.Id == 0 ?
            EntityState.Added :
            EntityState.Modified;

            var response = await _context.SaveChangesAsync();

            var result = new Client();
            if (response != 0)
            {

                 result = _context.Clients
                    .FirstOrDefault(m => m.Id == item.Id);

            }

            return result;
        }
    }
}
