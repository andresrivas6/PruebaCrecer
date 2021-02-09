using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infrastructure;


namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        private pruebaCrecerEntities dbContext = new pruebaCrecerEntities();

        [HttpGet]
        public List<usuario> Get() {
            List<usuario> usuarios = new List<usuario>();

            try
            {
                using (pruebaCrecerEntities bd = new pruebaCrecerEntities())
                {
                    //List<Usuario> u = new List<Usuario>();  
                    //u = bd.usuario.ToList();
                    usuarios = bd.usuario.ToList();
                    return usuarios;
                }
            }catch(Exception ex)
            {
                return usuarios;
            }
        }

        // Obtener solamente 1
        [HttpGet]
        public usuario GetUsuario(int id)
        {
            usuario usuario = new usuario();
            try
            {
                using (pruebaCrecerEntities bd = new pruebaCrecerEntities())
                {
                    //List<Usuario> u = new List<Usuario>();  
                    //u = bd.usuario.ToList();
                    usuario = dbContext.usuario.FirstOrDefault(u => u.id == id); //bd.usuario.ToList();
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                return usuario;
            }
        }

        // agregar uno nuevo
        [HttpPost]
        public IHttpActionResult AddUsuario([FromBody]usuario user)
        {
            
            try
            {
                dbContext.usuario.Add(user);
                dbContext.SaveChanges();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();   
            }
        }


        //Modificar un registro
        [HttpPut]
        public IHttpActionResult UpdateUsuario(int id,[FromBody] usuario user)
        {
            try
            {
                var usuarioExiste = dbContext.usuario.Count(u => u.id == id) > 0;

                if (usuarioExiste)
                {
                    dbContext.Entry(user).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        // Eliminar un registro
        [HttpDelete]
        public IHttpActionResult DeleteUsuario(int id)
        {
            var usuario =  dbContext.usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            dbContext.usuario.Remove(usuario);
            dbContext.SaveChanges();
            return Ok(usuario);
            
        }

    }
}
