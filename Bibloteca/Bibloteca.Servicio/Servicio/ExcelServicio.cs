using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibloteca.Servicio.Servicio
{
    public interface IExcelServicio
    {
         byte[] GetExcelLoans();
        byte[] GetExcelBooks();

        byte[] GetExcelUsers();
    }
    public class ExcelServicio:IExcelServicio
    {
       
        private readonly ILibroServicio _libroServicio;
        private readonly IPrestamoServicio _prestamoServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        public ExcelServicio(IPrestamoServicio prestamoServicio, ILibroServicio libroServicio, IUsuarioServicio usuarioServicio)
        {
            _prestamoServicio = prestamoServicio;
            _libroServicio = libroServicio;
            _usuarioServicio = usuarioServicio;
        }

        public byte[] GetExcelLoans()
        {
            byte[] fileContents;
            IEnumerable<Reporte> prestamos = _prestamoServicio.GetPrestamos();

            using (var package = new ExcelPackage())
            {
                int row = 1;

                var worksheet = package.Workbook.Worksheets.Add("ReporteLoans");

                CrearHeader(row, 1, "Id", worksheet);
                CrearHeader(row, 2, "Folio", worksheet);
                CrearHeader(row, 3, "Fecha", worksheet);
                CrearHeader(row, 4, "Devolucion", worksheet);
                CrearHeader(row, 5, "Estado", worksheet);
                CrearHeader(row, 6, "Nombres", worksheet);
                CrearHeader(row, 7, "Carrera", worksheet);
                CrearHeader(row, 8, "Telefono", worksheet);
                CrearHeader(row, 9, "Email", worksheet);
                CrearHeader(row, 10, "Pedido", worksheet);


                foreach (Reporte _reporte in prestamos)
                {
                    row++;
                    worksheet.Cells[row, 1].Value = _reporte.Id.ToString();
                    worksheet.Cells[row, 2].Value = _reporte.Folio.ToUpper();
                    worksheet.Cells[row, 3].Value = _reporte.Fecha.ToShortDateString();
                    worksheet.Cells[row, 4].Value = _reporte.Devolucion.ToShortDateString();
                    worksheet.Cells[row, 5].Value = _reporte.Estado.ToString();
                    worksheet.Cells[row, 6].Value = _reporte.Nombres.ToString();
                    worksheet.Cells[row, 7].Value = _reporte.Carrera.ToString();
                    worksheet.Cells[row, 8].Value = _reporte.Telefono.ToString();
                    worksheet.Cells[row, 9].Value = _reporte.Email.ToString();
                    worksheet.Cells[row, 10].Value = _reporte.Pedido.ToString();
                }

                fileContents = package.GetAsByteArray();

                return fileContents;
            }
            
        }

        public byte[] GetExcelUsers()
        {
            byte[] fileContents;

            IEnumerable<Usuario> usuarios = _usuarioServicio.GetTodos();

            using (var package = new ExcelPackage())
            {
                int row = 1;

                var worksheet = package.Workbook.Worksheets.Add("ReporteUsers");

                CrearHeader(row, 1, "Id", worksheet);
                CrearHeader(row, 2, "Mote", worksheet);
                CrearHeader(row, 3, "Nombre", worksheet);
                CrearHeader(row, 4, "Apellido", worksheet);
                CrearHeader(row, 5, "Activo", worksheet);
                CrearHeader(row, 6, "Matricula", worksheet);
                CrearHeader(row, 7, "Telefono", worksheet);
                CrearHeader(row, 8, "Email", worksheet);
                CrearHeader(row, 9, "Carrera", worksheet);
                CrearHeader(row, 10, "Cuatrimestre", worksheet);
                CrearHeader(row, 11, "Grupo", worksheet);

                foreach (Usuario _reporte in usuarios)
                {
                    row++;
                    worksheet.Cells[row, 1].Value = _reporte.Id.ToString();
                    worksheet.Cells[row, 2].Value = _reporte.Mote.ToString();
                    worksheet.Cells[row, 3].Value = _reporte.Nombre.ToString();
                    worksheet.Cells[row, 4].Value = _reporte.Apellido.ToString();
                    worksheet.Cells[row, 5].Value = _reporte.Activo.ToString();
                    worksheet.Cells[row, 6].Value = _reporte.Matricula.ToString();
                    worksheet.Cells[row, 7].Value = _reporte.Telefono.ToString();
                    worksheet.Cells[row, 8].Value = _reporte.Email.ToString();
                    worksheet.Cells[row, 9].Value = _reporte.Carrera.ToString();
                    worksheet.Cells[row, 10].Value = _reporte.Cuatrimestre.ToString();
                    worksheet.Cells[row, 11].Value = _reporte.Grupo.ToString();
                }

                fileContents = package.GetAsByteArray();

                return fileContents;

            }
        }

        public byte[] GetExcelBooks()
        {
            byte[] fileContents;

            IEnumerable<Libro> libros = _libroServicio.GetLibros();

            using (var package = new ExcelPackage())
            {
                int row = 1;

                var worksheet = package.Workbook.Worksheets.Add("ReporteBooks");

                CrearHeader(row, 1, "Id", worksheet);
                CrearHeader(row, 2, "Folio", worksheet);
                CrearHeader(row, 3, "Nombre", worksheet);
                CrearHeader(row, 4, "Autor", worksheet);
                CrearHeader(row, 5, "Genero", worksheet);
                CrearHeader(row, 6, "Estante", worksheet);
                CrearHeader(row, 7, "Año", worksheet);
                CrearHeader(row, 8, "Editorial", worksheet);
                CrearHeader(row, 9, "Paginas", worksheet);
                CrearHeader(row, 10, "Stock", worksheet);

                foreach (Libro _reporte in libros)
                {
                    row++;
                    worksheet.Cells[row, 1].Value = _reporte.Id.ToString();
                    worksheet.Cells[row, 2].Value = _reporte.Folio.ToUpper();
                    worksheet.Cells[row, 3].Value = _reporte.Nombre.ToString();
                    worksheet.Cells[row, 4].Value = _reporte.Autor.ToString();
                    worksheet.Cells[row, 5].Value = _reporte.Genero.ToString();
                    worksheet.Cells[row, 6].Value = _reporte.Estante.ToString();
                    worksheet.Cells[row, 7].Value = _reporte.Anio.ToString();
                    worksheet.Cells[row, 8].Value = _reporte.Editorial.ToString();
                    worksheet.Cells[row, 9].Value = _reporte.Paginas.ToString();
                    worksheet.Cells[row, 10].Value = _reporte.Stock.ToString();
                }

                fileContents = package.GetAsByteArray();

                return fileContents;
            }
        }



            private void CrearHeader(int indexRow, int indexCol, string NombreColumna, ExcelWorksheet excelWorksheet)
        {
            excelWorksheet.Cells[indexRow, indexCol].Value = NombreColumna;
            excelWorksheet.Cells[indexRow, indexCol].Style.Font.Size = 12;
            excelWorksheet.Cells[indexRow, indexCol].Style.Font.Bold = true;
            excelWorksheet.Cells[indexRow, indexCol].AutoFitColumns();
            excelWorksheet.Cells[indexRow, indexCol].AutoFilter = true;

        }
    }

   

}

