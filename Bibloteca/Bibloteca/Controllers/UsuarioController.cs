using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Recursos;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibloteca.Controllers
{
    //[Authorize (Roles =  "Admin")]
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        // GET: api/Usuario
        private readonly IUsuarioServicio _usuarioServicio;
 
        public UsuarioController(IUsuarioServicio userService)
        {
            this._usuarioServicio = userService;
            
        }
        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            try
            {
                
                return Ok(_usuarioServicio.GetTodos());

            }
            catch (Exception)
            {

                return BadRequest(Mensajes.UsuarioError);
            }
        }

       

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try

            {
                return Ok(_usuarioServicio.Get(id));
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        
        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody]Usuario value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioServicio.Add(value);
                    return Ok(200);
                }
                else
                {
                    return BadRequest("No se pudo insertar el usuario");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        
        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Usuario value)
        {
            return Ok(_usuarioServicio.Update(value));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_usuarioServicio.Delete(id))
                    return Ok();
                else return BadRequest(Mensajes.UsuariosEliminadoError);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
