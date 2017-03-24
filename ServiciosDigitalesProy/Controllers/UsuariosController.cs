using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Datos;
using ServiciosDigitalesProy.Catalogos;
namespace ServiciosDigitalesProy.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private bdServiciosDigitalesProyEntities conexion = new bdServiciosDigitalesProyEntities();

        #region Clientes
        [HttpGet]
        public ActionResult ConsultarClientes()
        {
            return View();
        }

        /// <summary>
        /// Consulta Los clientes segun su identificación.  si el valor es vacio, entonces trae la consulta total
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConsultarClientes(string identificacion)
        {
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(identificacion);

            return View("RespuestaConsultaClientes",usuarios);
        }

        // POST: Usuarios/Create
        [HttpGet]
        public ActionResult AdicionarCliente()
        {
            Usuario user = new Usuario();
            user.tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(),"id", "Descripcion");
            return View(user);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult AdicionarCliente(Usuario user)
        {
            if (ModelState.IsValid)
            {
                CatalogoUsuarios.GetInstance().AdicionarCliente(user);
                return RedirectToAction("ConsultarClientes");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ModificarCliente(string id)
        {
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id);
            usuarios.First().tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            usuario = usuarios.First();
            return View(usuario);
        }

        //[HttpPost]
        //public ActionResult ModificarCliente()
        //{
        //    List<Usuario> usuarios;
        //    usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(identificacion);

        //    return View("RespuestaConsultaClientes", usuarios);
        //}

        #endregion

    }
}
