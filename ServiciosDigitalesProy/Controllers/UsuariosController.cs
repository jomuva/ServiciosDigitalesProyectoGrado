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
            TempData["identificacionConsulta"] = identificacion;
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
            string resp;
            if (ModelState.IsValid)
            {
                resp = CatalogoUsuarios.GetInstance().AdicionarCliente(user);
                return RedirectToAction("ConsultarClientes");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ModificarCliente(string id)
        {
            string resp;
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id);
            if (usuarios.First().estado == "Bloqueado" || usuarios.First().estado == "Eliminado" || usuarios.First().estado == "Inactivo"|| usuarios.First().estado == "")
            {
                resp = "El usuario no se encuentra Activo";
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"));
                return View("RespuestaConsultaClientes", usuarios);
            }
            usuarios.First().tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            usuario = usuarios.First();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult UpdateCliente(Usuario user)
        {
            string resp;
            if (ModelState.IsValid)
            {
                resp= CatalogoUsuarios.GetInstance().ModificarCliente(user);
                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"));
                return View("RespuestaConsultaClientes", usuarios);

            }

            return View();
        }

        [HttpGet]
        public ActionResult CambiarEstadoCliente(string id)
        {
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id);
            usuario = usuarios.First();
            //CatalogoUsuarios.GetInstance().CambiarEstadoCliente(usuario);
            usuario.tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion");

            return View(usuario);
        }

        [HttpPost]
        public ActionResult ModificarEstadoCliente(Usuario usuario)
        {
            string resp;
            resp = CatalogoUsuarios.GetInstance().CambiarEstadoCliente(usuario);
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"));
            return View("RespuestaConsultaClientes", usuarios);
        }

        [HttpGet]
        public ActionResult DetallesCliente(string id)
        {
            List<Usuario> usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id);

            return View("DetallesCliente",usuarios.First());
        }

        [HttpGet]
        public ActionResult VolverDetallesCliente(string id)
        {
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id);
            return View("RespuestaConsultaClientes", usuarios);
        }

        #endregion

    }
}
