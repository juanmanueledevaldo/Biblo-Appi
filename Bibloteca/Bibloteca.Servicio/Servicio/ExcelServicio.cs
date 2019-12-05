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
         byte[] Get();
    }
    public class ExcelServicio:IExcelServicio
    {
        private readonly ILibroRepositorio _libroRepositorio;
        public ExcelServicio(ILibroRepositorio libroRepositorio)
        {
            _libroRepositorio = libroRepositorio;
        }

        public byte[] Get()
        {
            byte[] fileContents;
            int recordIndex = 1;
            var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
            IEnumerable<Libro> libros = _libroRepositorio.GetTodos();
            foreach (var item in libros)
            {
                worksheet.Cells[recordIndex, 1].Value = item.Id;
                recordIndex++;

            }
            fileContents = package.GetAsByteArray();
            if (fileContents ==null||fileContents.Length==0)
            {
                return null;
            }
            return fileContents;
        }
    }
}
