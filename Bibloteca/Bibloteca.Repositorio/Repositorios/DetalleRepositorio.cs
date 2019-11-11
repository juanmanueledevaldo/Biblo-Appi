using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface IDetalleRepositorio
    {
        int Insert(Detalle detalle);
    }
    public class DetalleRepositorio : IDetalleRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();
        public int Insert(Detalle detalle)
        { 
            _db.Detalle.Add(detalle);
            _db.SaveChanges();
            return 1;
        }
    }
}
