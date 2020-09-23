using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;


namespace FinanWPF.Models
{
    class Context : DbContext
    {
        
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=FinanC;Trusted_Connection=True;");

            optionsBuilder.UseLazyLoadingProxies();

        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer(myConnectionString);
        */






    }
}
