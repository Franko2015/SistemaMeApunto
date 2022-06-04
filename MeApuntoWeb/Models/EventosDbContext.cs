﻿using Microsoft.EntityFrameworkCore;

namespace MeApuntoWeb.Models
{
    public class EventosDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var conString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conString);
        }

        //Instancia de tablas para la BD
        public DbSet<Categoria>? tblCategoria { get; set; }
        public DbSet<Estado>? tblEstado { get; set; }
        public DbSet<Evento>? tblEvento { get; set; }
        public DbSet<Lugar>? tblLugar { get; set; }
        public DbSet<TipoUsuario>? tblTipo_usuario { get; set; }
        public DbSet<Usuario>? tblUsuario { get; set; }
    }
}
