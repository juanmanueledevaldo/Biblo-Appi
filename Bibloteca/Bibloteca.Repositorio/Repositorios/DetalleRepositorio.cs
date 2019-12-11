using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface IDetalleRepositorio
    {
        int Insert(Detalle detalle);
        int Delete(int id);
        IEnumerable<Pendiente> GetAll();
        IEnumerable<Resenia> Get(int id);
        Detalle Update(IEnumerable <Detalle> detalle);
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

        public IEnumerable<Resenia> Get(int id)
        {
            var Detalles = from lib in _db.Libro
                           join det in _db.Detalle
                           on lib.Id equals det.Libroi
                           join pre in _db.Prestamo
                           on det.Prestamoi equals pre.Id
                           where lib.Id == id
                           select new Resenia
                           {
                               Fecha = pre.Fecha,
                               Comentario = det.Comentario,
                               Folio = pre.Folio,
                               Id = det.Id
                           };
            return Detalles;
        }

        public IEnumerable<Pendiente> GetAll()
        {
            var Pendiente = from lib in _db.Libro
                            join det in _db.Detalle
                            on lib.Id equals det.Libroi
                            
                            select new Pendiente
                            {
                                Id = det.Id,
                                Detalle = lib.Id,
                                Estante = lib.Estante,
                                Folio = lib.Folio,
                                Genero = lib.Genero,
                                Imagen = lib.Imagen,
                                Nombre = lib.Nombre,
                                Stock = lib.Stock,
                                Comentario = det.Comentario
                            };
            return Pendiente;
                      
                      
        }

        public int Insert(Detalle detalle)
        { 
            _db.Detalle.Add(detalle);
            _db.SaveChanges();
            return 1;
        }

        public Detalle Update(IEnumerable<Detalle> detalle)
        {
            _db.Entry(detalle).State = EntityState.Modified;
            _db.SaveChanges();

            return null;

        }
    }
}
