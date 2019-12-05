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
       Usuario GetTodos();
        Usuario Get(Usuario id);
        int Insert(Usuario usuario);
        Usuario Update(Usuario usuario);
        Usuario GetLogin(Login logeado);
        bool Delete(Usuario id);
    }
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public bool Delete(Usuario id)
        {
            //    Usuario usuario = new Usuario();
            //Task<Usuario> usuarioTask = _db.Usuario.FirstOrDefaultAsync(us => us.Id == id);
            //usuario = usuarioTask.Result;
            //    _db.Usuario.Remove(usuario);
            //    _db.SaveChanges();

            var user = Get(id);
            user.Activo = !user.Activo;
            _db.Usuario.Update(user);
            _db.SaveChanges();
            return true;
           
        }
        public Usuario GetLogin(Login logeado)
        {


            List<Usuario> login = _db.Usuario.ToList<Usuario>();
            return null;
        }

    public Usuario Get(Usuario id)
        {
            return _db.Usuario.FirstOrDefault(us => us.Id == id.Id);
        }

        public Usuario GetTodos()
        {
            var usuarios = from usu in _db.Usuario
                         
                         
                          select new Usuario
                          {
                              Id = usu.Id,
                              Mote = usu.Mote,
                              Nombre = usu.Nombre,
                              Apellido = usu.Apellido,
                              Tipo = usu.Tipo 

                          };
            return usuarios.FirstOrDefault();
        }

        public int Insert(Usuario usuario)
        {
               
                _db.Add(usuario);
                _db.SaveChanges();
                return 1;
        }

        public Usuario Update(Usuario usuario)
        {
            try
            {
                _db.Entry(usuario).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Usuario.FirstOrDefault(us => us.Id == usuario.Id);
            }
            catch (Exception)
            {
                return null;
            }
        }

       
    }
}
