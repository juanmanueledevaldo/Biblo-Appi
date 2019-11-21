﻿using System;
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
        public DetalleController(IDetalleServicio detalleServicio)
        {
            this._detalleServicio = detalleServicio;
        }
        // GET: api/Detalle
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_detalleServicio.GetDetalles());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/Detalle/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
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
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(
                    _detalleServicio.Delete(id)
                    );
                
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
