using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\PrimerParcial.db");
        }
    }
}
