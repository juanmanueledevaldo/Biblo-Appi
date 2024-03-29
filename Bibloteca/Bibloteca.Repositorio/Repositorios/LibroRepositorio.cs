﻿using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> GetTodos();
        Task<Libro> Get(string id);
        int Insert(Libro libro);
        Task<Libro> Update(Libro libro);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();
        public Task<Libro> Get(string id)
        {
            return _db.Libro.FirstOrDefaultAsync(li => li.Id == id);
        }

        public IEnumerable<Libro> GetTodos()
        {
            return _db.Libro;

        }

        public int Insert(Libro libro)
        {
            libro.Id = "";
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

        public Task<Libro> Update(Libro libro)
        {
            try
            {
                _db.Entry(libro).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Libro.FirstOrDefaultAsync(li => li.Id == libro.Id);

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
