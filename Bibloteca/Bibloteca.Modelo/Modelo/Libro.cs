
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere capturar el id del libro")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo numeros y letras.")]
        public string Folio { get; set; }
        [Required(ErrorMessage = "Se requiere el nombre del libro")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo numeros y letras.")]
        [MaxLength(100)]
        public string Nombre { get; set; }
       
        [Required(ErrorMessage = "Se requiere capturar el nombre del autor")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        [MaxLength(50)]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Se requiere capturar el genero del libro")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        [MaxLength(50)]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Se requiere capturar el nombre del autor")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo numeros y letras.")]
        [MaxLength(30)]
        public string Estante { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de devolución")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Año { get; set; }
        [Required(ErrorMessage = "Se requiere capturar la editorial")]
        public string Editorial { get; set; }
        [Required (ErrorMessage = "Se requiere capturar el numero de paginas que tiene el libro")]
        public int Paginas { get; set; }
      
        public bool Borrado { get; set; }
        [Required (ErrorMessage = "Se requiere capturar los libros que se van a registrar")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        [RegularExpression("^\\d+$", ErrorMessage = "El stock debe contener sólo números.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Se requiere una url de la imagen")]
        public string Imagen { get; set; }
    }
}
