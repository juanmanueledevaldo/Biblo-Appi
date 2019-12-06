using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Pendiente
    {
        public int Detalle { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Folio { get; set; }
        public string Estante { get; set; }
        public string Genero { get; set; }
        public int Stock { get; set; }
        public string Comentario { get; set; }
    }
}
