using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchDatenbank
{
    public class DatenbankKontext : DbContext
    {
        private readonly string _connectionString;

        public DatenbankKontext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }

        public DbSet<BuchDTO> Buecher { get; set; }
        public DbSet<Buch2DTO> Buecher2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuchDTO>().HasKey(e => e.Id);
        }
        
        
    }
}
