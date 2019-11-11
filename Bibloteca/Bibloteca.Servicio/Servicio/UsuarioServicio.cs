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
        Task<Usuario> Get(string id);
        void Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);  
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
        public Task<Usuario> Get(string id)
        {
            return _usuarioRepositorio.Get(id);

        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _usuarioRepositorio.GetTodos();

        }

        public Task<Usuario> Update(Usuario usuario)
        {
            return _usuarioRepositorio.Update(usuario);
        }
    }
}
