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
using Bibloteca.Recursos;
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
        //[HttpGet]
        //[Authorize(Roles = "Admin") ]
        //public Object Get(Usuario id)
        //{
           
        //    var userClaims = HttpContext.User.Claims;

        //    if (User == null)
        //    {
        //        return BadRequest("Error no se ha logeado");
        //    }
        //    else
        //    {
        //        int userID = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
        //        var user = _usuarioServicio.Get(id);
        //        return new
        //        {
        //            user.Mote,
        //            user.Nombre,
        //            user.Tipo
                   
        //        };

               
        //    }
                  
                
        //    }
           
          

        // GET: api/Login/5
       
        [HttpGet]
        [Authorize]
        //[Route("Admin")]
        public IActionResult Admin()
        {

            try
            {

                var claims = HttpContext.User.Claims;
                var tip = HttpContext.User.Claims.FirstOrDefault(x => x.Type  == ClaimTypes.Role).Value; 
               return Ok(tip);
               

            }
            catch (Exception e)
            {

                return BadRequest();
            }
        } 
        
        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]Login value)
        {
            try

            {
                Usuario userExistente = _usuarioServicio.Login(value);
                if (userExistente.Mote  ==null )
                {
                    if (userExistente.Contrasenia == null)
                    {
                        return BadRequest(Mensajes.LoginError);
                    }
                    else { return BadRequest(Mensajes.LoginError); }
                }
                else
                {


                    List<Claim> claims = new List<Claim>();
                    //se añade el rol al claim
                    claims.Add(new Claim(ClaimTypes.Role, Convert.ToString(userExistente.Tipo)));
                    claims.Add(new Claim("Id",userExistente.Id.ToString()));
                    claims.Add(new Claim("Mote",userExistente.Mote.ToString())); 
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

                return BadRequest(e);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("api/login/UserProfile")]
        //GET : /api/UserProfile
      

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
