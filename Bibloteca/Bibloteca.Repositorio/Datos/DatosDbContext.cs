using Bibloteca.Modelo.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Repositorio.Datos
{

    class DatosDbContext : DbContext
    {
        private readonly string cadena1 = "Data Source = .; Initial Catalog = EPBIBLIOTECA; Integrated Security = True";
        private readonly string cadena = "data source=(local);Initial catalog=EPBIBLIOTECA;user id=sa; password=rodrigo;";


        public DatosDbContext()
        {

        }
        
        public DatosDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(cadena
                    );
            }
        }


        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Estudiante> Estudiante{ get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


    }
}
