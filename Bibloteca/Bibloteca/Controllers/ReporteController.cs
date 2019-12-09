using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bibloteca.Servicio.Servicio;

namespace Bibloteca.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]")]
    [Route("api/Reporte")]
    public class ReporteController : Controller
    {
        private readonly IExcelServicio _excelServicio;
        

        public ReporteController(IExcelServicio excelServicio)
        {
            _excelServicio = excelServicio;
        }
        // GET: api/Reporte
        
        //[HttpGet ("{GetExcelLoans}", Name ="GetExcelLoans")]
        [Route("GetExcelLoans")]
        //[Route("Reporte/")]
        public IActionResult GetExcelLoans()
        {
            try
            {
                var fileContents = _excelServicio.GetExcelLoans();
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Route("GetExcelUsers")]
        public IActionResult GetExcelUsers()
        {
            try
            {
                var fileContents = _excelServicio.GetExcelUsers();
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "Reporte De Usuarios.xlsx");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[HttpGet("{GetExcelBooks}", Name = "GetExcelBooks")]
        [Route("GetExcelBooks")]
        public IActionResult GetExcelBooks()
        {
            try
            {
                var fileContents = _excelServicio.GetExcelBooks();
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "Reporte De Libros.xlsx");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/Reporte/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Reporte
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Reporte/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
