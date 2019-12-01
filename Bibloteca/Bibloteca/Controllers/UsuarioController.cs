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
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        // GET: api/Usuario
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IEmailSender _emailSender;
        public UsuarioController(IUsuarioServicio userService, IEmailSender emailSender)
        {
            this._usuarioServicio = userService;
            this._emailSender = emailSender;
        }
        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            try
            {

                return Ok(_usuarioServicio.GetUsuarios());

            }
            catch (Exception)
            {

                return BadRequest(Mensajes.UsuarioError);
            }
        }

        public async Task <IActionResult>SendEmail ()
        {
            await _emailSender.SendEmailAsync("3amprg.gomez.vallejo.rodrigo@gmail.com", "Recado", "Este es un imail").ConfigureAwait(false);
            return View();
                
                }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_usuarioServicio.Get(id));
        }

        
        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody]Usuario value)
        {
            try
            {
                _usuarioServicio.Add(value);
                return Ok(200);
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
        public void Delete(int id)
        {
            
        }
    }
}
