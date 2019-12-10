using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Detalle
    {
        public int Id { get; set; }
        public Nullable<int> Libroi { get; set; }
        public Nullable<int> Prestamoi { get; set; }
        public string Comentario { get; set; }
        public Prestamo Prestamo { get; set; }
        public Libro Libro { get; set; }
    }
}
