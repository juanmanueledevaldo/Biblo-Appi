using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Se requiere la fecha de prestamo")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de devolución")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Devolucion { get; set; }
        [Required]
        public string  Estado { get; set; }
        
     [ForeignKey("Usu")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("Det")]
        public virtual Detalle Detalle { get; set; }
        public int? DetId { get; set; }
        public int? UsuId { get; set; }
    }
}
