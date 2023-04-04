using JoaquinCineAPI.Modelo.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JoaquinCineAPI.Infraestructura
{
    public class DBContext : DbContext
    {
        //public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DBContext() : base() { }
        //tablas
        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Peli)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.PeliId);
        }
    }
}
