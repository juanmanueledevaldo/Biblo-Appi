using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Detalle
    {
        
        public int? Id { get; set; }
        [ForeignKey("Lib")]
        public virtual Libro Libro { get; set; }
    }
}
