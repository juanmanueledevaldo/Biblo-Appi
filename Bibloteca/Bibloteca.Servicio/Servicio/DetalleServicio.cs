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
        int Remove(int id);
        IEnumerable<Pendiente> GetDetalles();
        Detalle Update(IEnumerable< Detalle > detalle);
        
    }
    public class DetalleServicio : IDetalleServicio
    {
        private readonly IDetalleRepositorio _detalleRepositorio;
        private readonly ILibroRepositorio _libroRepositorio;
        public DetalleServicio(IDetalleRepositorio detalleRepositorio, ILibroRepositorio libroRepositorio)
        {
            _detalleRepositorio = detalleRepositorio;
            _libroRepositorio = libroRepositorio;
        }
        public void Add(Detalle detalle)
        {
           
            _libroRepositorio.Restar(detalle.Libroi);
            _detalleRepositorio.Insert(detalle);
            
            
        }

        public IEnumerable<Pendiente> GetDetalles()
        {
            return _detalleRepositorio.GetAll();
        }

        public int Remove(int id)
        {
            _libroRepositorio.Sumar(id);

            return _detalleRepositorio.Delete(id);
        }

        public Detalle Update(IEnumerable <Detalle>detalle)
        {
            return _detalleRepositorio.Update(detalle);
           
        }
    }
}
