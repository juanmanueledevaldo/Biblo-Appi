using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;

namespace Bibloteca.Servicio.Servicio
{
    public interface IUsuarioServicio
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario Get(int id);
        void Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Usuario Login(Login login);
       
    }
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
        public void Add(Usuario usuario)
        {
            _usuarioRepositorio.Insert(usuario);
        }
        public Usuario Get(int id)
        {
            return _usuarioRepositorio.Get(id).Result;

        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _usuarioRepositorio.GetTodos();

        }

        public Usuario Login(Login login)
        {
            return _usuarioRepositorio.GetLogin(login);
        }

        public Task<Usuario> Update(Usuario usuario)
        {
            return _usuarioRepositorio.Update(usuario);
        }
    }
}
