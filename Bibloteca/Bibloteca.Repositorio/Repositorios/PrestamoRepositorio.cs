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
        IEnumerable<Reporte> GetTodos();
        Reporte Get(int id);
    }
    public class PrestamoRepositorio:IPrestamoRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public Reporte Get(int id)
        {
            var reporte = from lib in _db.Libro
                           join det in _db.Detalle
                           on lib.Id equals det.Libroi
                           join pre in _db.Prestamo
                           on det.Prestamoi equals pre.Id
                           join usu in _db.Usuario
                           on pre.Usuarioi equals usu.Id
                           where (pre.Id == id)
                           select new Reporte
                           {
                               Id = pre.Id,
                               Folio = pre.Folio,
                               Nombres = $"{usu.Nombre} {usu.Apellido}",
                               Fecha = pre.Fecha,
                               Devolucion = pre.Devolucion,
                               Estado = pre.Estado,
                               Pedido = lib.Nombre,

                           };
            return reporte.FirstOrDefault();
        }

        public IEnumerable<Reporte> GetTodos()
        {
            var reportes = from lib in _db.Libro
                          join det in _db.Detalle
                          on lib.Id equals det.Libroi
                          join pre in _db.Prestamo
                          on det.Prestamoi equals pre.Id
                          join usu in _db.Usuario
                          on pre.Usuarioi equals usu.Id
                          select new Reporte
                          {
                              Id = pre.Id,
                              Folio = pre.Folio,
                              Nombres = $"{usu.Nombre} {usu.Apellido}",
                              Fecha = pre.Fecha,
                              Devolucion = pre.Devolucion,
                              Estado = pre.Estado,
                              Pedido = lib.Nombre,
                              
                          };
            return reportes;
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
