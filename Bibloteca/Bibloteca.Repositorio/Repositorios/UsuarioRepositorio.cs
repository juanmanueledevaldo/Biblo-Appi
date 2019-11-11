using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca.Repositorio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetTodos();
        Task<Usuario> Get(string id);
        int Insert(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
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

    public Task<Usuario> Get(string id)
        {
            return _db.Usuario.FirstOrDefaultAsync(us => us.User == id);
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
                return _db.Usuario.FirstOrDefaultAsync(us => us.User == usuario.User);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
