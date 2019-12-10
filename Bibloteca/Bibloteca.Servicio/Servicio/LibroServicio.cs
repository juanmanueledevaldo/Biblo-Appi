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
        Libro Get(int id);
        void Add(Libro libro);
        Libro Update(Libro libro);
        bool Delete(int id);
        void Restar(int id);
        void Sumar(int id);
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

        public bool Delete(int id)
        {
            return _libroRepositorio.Delete(id);
        }

        public Libro Get(int id)
        {
            return _libroRepositorio.Get(id);
        }

        public IEnumerable<Libro> GetLibros()
        {
            return _libroRepositorio.GetTodos();
        }

        public void Restar(int id)
        {
             _libroRepositorio.Restar(id);
        }

        public void Sumar(int id)
        {
             _libroRepositorio.Sumar(id);
        }

        public Libro Update(Libro libro)
        {
            return _libroRepositorio.Update(libro);
        }
    }
}
