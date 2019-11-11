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
    public interface IPrestamoRepositorio
    {
        int Insert(Prestamo prestamo);
        Task<Prestamo> Update(Prestamo prestamo);
        IEnumerable<Prestamo> GetTodos();
    }
    public class PrestamoRepositorio:IPrestamoRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public IEnumerable<Prestamo> GetTodos()
        {
            return _db.Prestamo;
        }

        public int Insert(Prestamo prestamo)
        {   
            prestamo.Fecha = DateTime.Now.Date;
            prestamo.Devolucion = DateTime.Now.Date;
            _db.Add(prestamo);
            _db.SaveChanges();
            return 1;
        }

        public Task<Prestamo> Update(Prestamo prestamo)
        {
            _db.Entry(prestamo).State = EntityState.Modified;
            _db.SaveChanges();
            return _db.Prestamo.FirstOrDefaultAsync(pr => pr.Id == prestamo.Id);
        }
    }
}
