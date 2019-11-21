using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Servicio.Servicio
{
    public interface IDetalleServicio
    {
        void Add(Detalle detalle);
        int Remove(int id);
        IEnumerable<Detalle> GetDetalles();
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

        public IEnumerable<Detalle> GetDetalles()
        {
            return _detalleRepositorio.GetAll();
        }

        public int Remove(int id)
        {
            return _detalleRepositorio.Delete(id);
        }
    }
}
