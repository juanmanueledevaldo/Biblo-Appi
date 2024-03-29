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
    [Route("api/Libro")]
    public class LibroController : Controller
    {
        private readonly ILibroServicio _libroServicio;
        public LibroController(ILibroServicio libroServicio)
        {
            this._libroServicio = libroServicio;
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
        public IActionResult Get(string id)
        {
            return Ok(_libroServicio.Get(id));
        }
        
        // POST: api/Libro
        [HttpPost]
        public IActionResult Post([FromBody]Libro value)
        {
            _libroServicio.Add(value);
            return Ok(200);
        }
        
        // PUT: api/Libro/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Libro value)
        {
            return Ok(_libroServicio.Update(value));
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
