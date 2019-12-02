using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetTodos();
        Task<Usuario> Get(int id);
        int Insert(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Usuario GetLogin(Login logeado);
    }
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public int Delete(int id)
        {
        //    Usuario usuario = new Usuario();
        //Task<Usuario> usuarioTask = _db.Usuario.FirstOrDefaultAsync(us => us.Id == id);
        //usuario = usuarioTask.Result;
        //    _db.Usuario.Remove(usuario);
        //    _db.SaveChanges();
            return 1;
        }
        public Usuario GetLogin(Login logeado)
        {

            var login = _db.Usuario;
            return login.Where(x => x.Mote == logeado.Mote && x.Contrasenia == logeado.Contrasenia ).FirstOrDefault();
        }

    public Task<Usuario> Get(int id)
        {
            return _db.Usuario.FirstOrDefaultAsync(us => us.Id == id);
        }

        public IEnumerable<Usuario> GetTodos()
        {
            return _db.Usuario;
        }

        public int Insert(Usuario usuario)
        {
               
                _db.Add(usuario);
                _db.SaveChanges();
                return 1;
        }

        public Task<Usuario> Update(Usuario usuario)
        {
            try
            {
                _db.Entry(usuario).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Usuario.FirstOrDefaultAsync(us => us.Mote == usuario.Mote);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
