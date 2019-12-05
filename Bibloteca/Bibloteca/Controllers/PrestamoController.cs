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
    [Route("api/Prestamo")]
    public class PrestamoController : Controller
    {
        private readonly IPrestamoServicio _prestamoServicio;
        private readonly IDetalleServicio _detalleServicio;
     
        public PrestamoController(IPrestamoServicio prestamoServicio, IDetalleServicio detalleServicio)
        {
            _prestamoServicio = prestamoServicio;
            _detalleServicio = detalleServicio; 

        }

        // GET: api/Prestamo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_prestamoServicio.GetPrestamos());
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_prestamoServicio.Get(id));

        }
        
        // POST: api/Prestamo
        [HttpPost]
        public IActionResult Post([FromBody]Prestamo value)
        {

                try
                {
                    _prestamoServicio.Add(value);
                    
                    return Ok(200);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            
          
        }
     
        // PUT: api/Prestamo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Prestamo value)
        {
            return Ok(_prestamoServicio.Update(value));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
