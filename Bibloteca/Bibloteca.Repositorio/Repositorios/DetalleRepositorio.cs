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
        IEnumerable<Libro> GetAll();

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

        public IEnumerable<Libro> GetAll()
        {
            //return _db.Detalle;
            var Pendiente = from lib in _db.Libro
                            join det in _db.Detalle
                            on lib.Id equals det.Libroi
                            select new Libro
                            {
                                Id=lib.Id,
                                Anio = lib.Anio,
                                Autor = lib.Autor,
                                Borrado = lib.Borrado,
                                Descripcion = lib.Descripcion,
                                Editorial = lib.Editorial,
                                Estante = lib.Estante,
                                Folio = lib.Folio,
                                Genero = lib.Genero,
                                Imagen = lib.Imagen,
                                Nombre = lib.Nombre,
                                Paginas = lib.Paginas,
                                Stock= lib.Stock
                            };
                           
                            
                           
            return Pendiente;
                      
                      
        }

        public int Insert(Detalle detalle)
        { 
            _db.Detalle.Add(detalle);
            _db.SaveChanges();
            return 1;
        }
    }
}
