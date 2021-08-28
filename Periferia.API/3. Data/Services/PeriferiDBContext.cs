using Microsoft.EntityFrameworkCore;
using Periferia.API._3._Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.API._3._Data.Services
{
    public class PeriferiDBContext:DbContext
    {
        public PeriferiDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SimpleSale> SimpleSales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "El Dorado", UnitValue = 1000000 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Miami International Airport", UnitValue = 1000000 });

            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, FirstName = "María", LastName = "Perez" , DocNumber = "1" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 2, FirstName = "José", LastName = "Perez" , DocNumber = "2" });
        }

    }
}
