
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25), Required(ErrorMessage = "Se necesita un nombre de usurio")]
        public string Mote { get; set; }
        [MaxLength(100), Required(ErrorMessage ="Se necesita capturar tu nombre" ), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        public string Nombre { get; set; }
        [MaxLength(100), Required(ErrorMessage = "Se necesita capturar tu apellido"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        public string Apellido { get; set; }
        [MaxLength(10), Required(ErrorMessage = "Se necesita capturar una contraseña"), MinLength(4)]
        public string Contraseña { get; set; }
        [Required (ErrorMessage = "Se requiere capturar si esta activo o no el usuario")]
        public bool Activo { get; set; }
        [Required(ErrorMessage = "Se requiere un Tipo de usuario")]
        public string Tipo { get; set; }
        public bool Borrado { get; set; }
    }
}
