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
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> GetTodos();
        Libro Get(int id);
        int Insert(Libro libro);
        Libro Update(Libro libro);
        bool Delete(int id);
        void Restar(int? id);
        void Sumar(int? id);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public bool Delete(int id)
        {
            var lib = Get(id);
            lib.Borrado = !lib.Borrado;
            _db.Libro.Update(lib);
            _db.SaveChanges();
            return true;
        }

        public Libro Get(int id)
        {
            Libro libro = new Libro();
            libro = _db.Libro.FirstOrDefault(li => li.Id == id);
            return libro;
        }

        public IEnumerable<Libro> GetTodos()
        {
            
            return _db.Libro;
        }

        public int Insert(Libro libro)
        {
            libro.Id = 0;
            try
            {
                _db.Add(libro);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void Restar(int? id)
        {
            Libro libro = new Libro();
            libro = _db.Libro.FirstOrDefault(li => li.Id == id);
            libro.Stock = libro.Stock-1;
            _db.Entry(libro).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Sumar(int?  id)
        {
            Libro libro = new Libro();
            libro = _db.Libro.FirstOrDefault(li => li.Id == id);
            libro.Stock = libro.Stock +1;
            _db.Entry(libro).State = EntityState.Modified;
            _db.SaveChanges();
            
        }

        public Libro Update(Libro libro)
        {
                _db.Entry(libro).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Libro.FirstOrDefault(li => li.Id == libro.Id);

            
        }
    }
}
