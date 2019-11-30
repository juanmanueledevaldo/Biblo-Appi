using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Modelo.Modelo
{
    public class Reporte
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Devolucion { get; set; }
        public string Estado { get; set; }
        public string Nombres { get; set; }
        public string Carrera { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pedido { get; set; }
    }
}
