using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Recursos;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibloteca.Controllers
{
    [Produces("application/json")]
    [Route("api/Libro")]
    public class LibroController : Controller
    {
        private readonly ILibroServicio _libroServicio;
        private readonly IExcelServicio _excelServicio;
        public LibroController(ILibroServicio libroServicio,  IExcelServicio excelServicio)
        {
            this._libroServicio = libroServicio;
            this._excelServicio = excelServicio;
        }
        [HttpGet]
        [Route("GetReporte")]
        public IActionResult GetReporte()
        {
            byte[] fileContents = _excelServicio.GetExcelLoans();

            return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.ms-excel",
                    fileDownloadName: "test.xlsx"
                    );
        }
        // GET: api/Libro
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_libroServicio.GetLibros());
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        // GET: api/Libro/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_libroServicio.Get(id));
        }
        
        // POST: api/Libro
        [HttpPost]
        public IActionResult Post([FromBody]Libro value)
        {
            if(ModelState.IsValid)
            {
                _libroServicio.Add(value);
                return Ok(200);
            }
            _libroServicio.Add(value);
            return BadRequest("No se pudo crear el libro");

        }
        
        // PUT: api/Libro/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Libro value)
        {
            return Ok(_libroServicio.Update(value));
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_libroServicio.Delete(id))
                    return Ok();
                else return BadRequest(Mensajes.LibrosBorradosError);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
