using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Servicio.Servicio
{
    public interface IPrestamoServicio
    {
        IEnumerable<Reporte> GetPrestamos();
        Reporte Get(int id);
        void Add(Prestamo prestamo);
        Task<Prestamo> Update(Prestamo prestamo);

        
    }
    public class PrestamoServicio: IPrestamoServicio
    {
        private readonly IPrestamoRepositorio _prestamoRepositorio;
        public PrestamoServicio(IPrestamoRepositorio prestamoRepositorio)
        {
            _prestamoRepositorio = prestamoRepositorio;
        }

        public void Add(Prestamo prestamo)
        {
            _prestamoRepositorio.Insert(prestamo);
        }

        public Reporte Get(int id)
        {
            return _prestamoRepositorio.Get(id);
        }

        public IEnumerable<Reporte> GetPrestamos()
        {
            return _prestamoRepositorio.GetTodos();

        }

        public Task<Prestamo> Update(Prestamo prestamo)
        {
            return _prestamoRepositorio.Update(prestamo);
        }
    }
}
