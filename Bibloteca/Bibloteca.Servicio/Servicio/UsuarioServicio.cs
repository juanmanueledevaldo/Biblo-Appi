using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bibloteca.Modelo.Modelo;
using Bibloteca.Repositorio.Repositorios;

namespace Bibloteca.Servicio.Servicio
{
    public interface IUsuarioServicio
    {
        IEnumerable < Usuario >GetTodos();
        Usuario Get(int id);
        void Add(Usuario usuario);
        Usuario Update(Usuario usuario);
        Usuario Login(Login login);
        bool Delete(Usuario id);
       
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

        public bool Delete(Usuario id)
        {
            return _usuarioRepositorio.Delete(id);
        }

        public Usuario Get(int id)
        {
            return _usuarioRepositorio.Get(id);

        }

        public IEnumerable< Usuario >GetTodos()
        {
            return _usuarioRepositorio.GetTodos();

        }

        public Usuario Login(Login login)
        {
            return _usuarioRepositorio.GetLogin(login);
        }

        public Usuario Update(Usuario usuario)
        {
            return _usuarioRepositorio.Update(usuario);
        }
      
    }
    
}
