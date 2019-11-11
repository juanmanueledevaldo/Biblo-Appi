using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Servicio.Servicio
{
    public interface ILibroServicio
    {
        IEnumerable<Libro> GetLibros();
        Task<Libro> Get(string id);
        void Add(Libro libro);
        Task<Libro> Update(Libro libro);
    }
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio _libroRepositorio;
        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            _libroRepositorio = libroRepositorio;

        }
        public void Add(Libro libro)
        {
            _libroRepositorio.Insert(libro);
        }
        public Task<Libro> Get(string id)
        {
            return _libroRepositorio.Get(id);
        }

        public IEnumerable<Libro> GetLibros()
        {
            return _libroRepositorio.GetTodos();
        }

        public Task<Libro> Update(Libro libro)
        {
            return _libroRepositorio.Update(libro);
        }
    }
}
