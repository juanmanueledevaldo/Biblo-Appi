﻿using Bibloteca.Modelo.Modelo;
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
        IEnumerable< Usuario> GetTodos();
        Usuario Get(int id);
        int Insert(Usuario usuario);
        Usuario Update(Usuario usuario);
        Usuario GetLogin(Login logeado);
        bool Delete(int id);
    }
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DatosDbContext _db = new DatosDbContext();

        public bool Delete(int id)
        {
   
    
            var user = Get(id);
            user.Activo = !user.Activo;
            _db.Usuario.Update(user);
            _db.SaveChanges();
            return true;
           
        }
        public Usuario GetLogin(Login logeado)
        {

            var login = _db.Usuario;
            return login.Where(x => x.Mote == logeado.Mote && x.Contrasenia == logeado.Contrasenia).FirstOrDefault();
        }

    public Usuario Get(int id)
        {
            return _db.Usuario.FirstOrDefault(us => us.Id == id);
        }

        public IEnumerable< Usuario >GetTodos()
        {
            return _db.Usuario;  
        }

        public int Insert(Usuario usuario)
        {
            
                _db.Add(usuario);
                _db.SaveChanges();
                return 1;
        }

        public Usuario Update(Usuario usuario)
        {
           
                _db.Entry(usuario).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Usuario.FirstOrDefault(us => us.Id == usuario.Id);
           
        }

       
    }
}
