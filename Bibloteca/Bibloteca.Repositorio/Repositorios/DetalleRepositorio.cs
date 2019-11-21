using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface IDetalleRepositorio
    {
        int Insert(Detalle detalle);
        IEnumerable<Detalle> GetTodos();
        int Delete(int id);
        //Detalle Get(int id);
        //Task<Detalle> Update(Detalle detalle);
    }
    public class DetalleRepositorio : IDetalleRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public int Delete(int id)
        {
            Detalle detalle = new Detalle();
            Task<Detalle> detalleTask = _db.Detalle.FirstOrDefaultAsync(d => d.Id == id);
            detalle = detalleTask.Result;
            _db.Detalle.Remove(detalle);
            _db.SaveChanges();
            return 1;
        }

        public IEnumerable<Detalle> GetTodos()
        {
            return _db.Detalle;
        }

        public int Insert(Detalle detalle)
        { 
            _db.Detalle.Add(detalle);
            _db.SaveChanges();
            return 1;
        }
    }
}
