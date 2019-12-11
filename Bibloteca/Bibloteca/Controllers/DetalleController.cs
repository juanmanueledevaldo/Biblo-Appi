using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibloteca.Controllers
{
    [Produces("application/json")]
    [Route("api/Detalle")]
    public class DetalleController : Controller
    {
        private readonly IDetalleServicio _detalleServicio;
        private readonly ILibroServicio _libroServicio;
        public DetalleController(IDetalleServicio detalleServicio,  ILibroServicio libroServicio)
        {
            this._detalleServicio = detalleServicio;
            this._libroServicio= libroServicio;
        }
        // GET: api/Detalle
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_detalleServicio.GetDetalles());
        }

        // GET: api/Detalle/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        
        // POST: api/Detalle
        [HttpPost]
        public IActionResult Post([FromBody]Detalle value)
        {
            try
            {
                _detalleServicio.Add(value);
                return Ok(200);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        
        // PUT: api/Detalle/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] IEnumerable< Detalle > value)
        {
            return Ok(_detalleServicio.Update(value));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_detalleServicio.Remove(id));
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
