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
        private readonly IDetalleRepositorio _detalleRepositorio;
        public PrestamoServicio(IPrestamoRepositorio prestamoRepositorio, IDetalleRepositorio detalleRepositorio)
        {
            _prestamoRepositorio = prestamoRepositorio;
            _detalleRepositorio = detalleRepositorio;
        }

        public void Add(Prestamo prestamo)

        {
            ICollection<Detalle> detalles;
            detalles =  prestamo.Detalle;
            prestamo.Detalle = null;
            _prestamoRepositorio.Insert(prestamo);
            _detalleRepositorio.Update(detalles);
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
