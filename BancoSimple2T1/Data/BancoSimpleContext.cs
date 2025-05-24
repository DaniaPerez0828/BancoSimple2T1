using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoSimple2T1.Models;

namespace BancoSimple2T1.Data
{
    public class BancoSimpleContext : DbContext
    {
        public DbSet   <Cliente> Cliente { get; set; }
        public DbSet <Cuenta> Cuenta { get; set;}
        public DbSet <Transaccion> Transacciones { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DANNIA0828\SQLEXPRESS; database=Banco;" + "Trusted_Connection = true; TrustServerCertificate = true");

        } 

        //Definicion de filtro global
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>().HasQueryFilter ( c => c.Activo);
        }

    }
}
