using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Detalle
    {
        public int Id { get; set; }
        public Nullable<int> LibroId { get; set; }
        public Nullable<int> PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
        public Libro Libro { get; set; }
    }
}
