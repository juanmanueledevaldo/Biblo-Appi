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
        Libro Get(Libro id);
        int Insert(Libro libro);
        Libro Update(Libro libro);
        bool Delete(Libro id);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public bool Delete(Libro id)
        {
            var lib = Get(id);
            lib.Borrado = !lib.Borrado;
            _db.Libro.Update(lib);
            _db.SaveChanges();
            return true;
        }

        public Libro Get(Libro id)
        {
            Libro libro = new Libro();
            libro = _db.Libro.FirstOrDefaultAsync(li => li.Id == id.Id).Result;
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

        public Libro Update(Libro libro)
        {
            try
            {
                _db.Entry(libro).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Libro.FirstOrDefault(li => li.Id == libro.Id);

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
