using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Estudiante:Usuario
    {
        [Required(ErrorMessage ="Se requiere una matricula")]
        
        [MaxLength(10 , ErrorMessage = "Solo se puede ingresar un valor de 10 caracteres")]
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
