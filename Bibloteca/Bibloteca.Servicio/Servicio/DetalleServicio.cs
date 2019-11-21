using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Servicio.Servicio
{
    public interface IDetalleServicio
    {
        void Add(Detalle detalle);
        IEnumerable<Detalle> GetDetalles();
        Detalle Get(int id);
        int Delete(int id);
        Task<Detalle> Update(Detalle detalle);
    }
    public class DetalleServicio : IDetalleServicio
    {
        private readonly IDetalleRepositorio _detalleRepositorio;
        public DetalleServicio(IDetalleRepositorio detalleRepositorio)
        {
            _detalleRepositorio = detalleRepositorio;
        }
        public void Add(Detalle detalle)
        {
            _detalleRepositorio.Insert(detalle);
            
        }

        public int Delete(int id)
        {
            return _detalleRepositorio.Delete(id);
        }

        public Detalle Get(int id)
        {
            return null;
        }

        public IEnumerable<Detalle> GetDetalles()
        {
            return _detalleRepositorio.GetTodos();
        }

        public Task<Detalle> Update(Detalle detalle)
        {
            return null;
        }
    }
}
