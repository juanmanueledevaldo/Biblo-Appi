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
    }
}
