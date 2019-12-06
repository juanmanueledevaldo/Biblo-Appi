
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
        //[MaxLength(25), Required(ErrorMessage = "Se necesita un nombre de usurio")]
        public string Mote { get; set; }
        //[MaxLength(100), Required(ErrorMessage ="Se necesita capturar tu nombre" ), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        public string Nombre { get; set; }
        //[MaxLength(100), Required(ErrorMessage = "Se necesita capturar tu apellido"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Usa solamente letras")]
        public string Apellido { get; set; }
        //[MaxLength(10), Required(ErrorMessage = "Se necesita capturar una contraseña"), MinLength(4)]
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
        //[Required(ErrorMessage = "Se requiere un Tipo de usuario")]
        public string Tipo { get; set; }
        public bool Borrado { get; set; }
        [Required(ErrorMessage = "Se requiere una matricula")]

        [MaxLength(10, ErrorMessage = "Solo se puede ingresar un valor de 10 caracteres")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Se requiere un numero de telefono")]
        [MaxLength(20)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un numero valido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Se requiere un correo electronico")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el correo es invalido")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Se requiere capturar la carrera en la que estudias")]
        [MaxLength(50)]
        public string Carrera { get; set; }
        [Required(ErrorMessage = "Se requiere capturar el cuatrimestre")]

        public int Cuatrimestre { get; set; }
        [Required(ErrorMessage = "Se requiere capturar el grupo")]
        [MaxLength(20)]
        public string Grupo { get; set; }
    }
}
