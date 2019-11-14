using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Servicio.Servicio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bibloteca.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public LoginController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
       
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]Login value)
        {
            try
            {
                Usuario userExistente = _usuarioServicio.Login(value);
                if (userExistente ==null)
                {
                    return BadRequest();
                }
                else
                {
                    List<Claim> claims = new List<Claim>();
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6ImxvcXVlc2VhIiwiaWF0IjoxNTE2MjM5MDIyfQ.KI2p5vksjJRiO_1R7qSkmeGZchby9gpuJHLPPkh2EUg"));
                    JwtSecurityToken token = new JwtSecurityToken(
                            claims: claims,
                            issuer: "issuer",
                            audience: "audience",
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                        );

                    return new OkObjectResult(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });

                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        // PUT: api/Login/5
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
