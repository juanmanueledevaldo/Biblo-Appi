using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Prestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prestamo()
        {
            Detalle = new HashSet<Detalle>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Folio { get; set; }
        [Required (ErrorMessage = "Se requiere la fecha del prestamo")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de devolución del prestamo")]
        public DateTime Devolucion { get; set; }
        [Required]
        public string  Estado { get; set; }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// 
        /// 
        /// 
        /// </summary>
        public virtual Usuario Usuario { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}
