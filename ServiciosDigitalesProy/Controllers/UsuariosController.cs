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

            string resultado="", tipoResultado="";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View();
            }
            else
            {
                return View("RespuestaConsultaClientes", usuarios);
            }
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
            string resultado = "", tipoResultado = "";

            if (ModelState.IsValid)
            {
                CatalogoUsuarios.GetInstance().AdicionarCliente(user,out resultado, out tipoResultado);

                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("RespuestaConsultaClientes", usuarios);
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View();
        }

        [HttpGet]
        public ActionResult ModificarCliente(string id)
        {
            string resp;
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);
            if (usuarios.First().estado == "Bloqueado" || usuarios.First().estado == "Eliminado" || usuarios.First().estado == "Inactivo"|| usuarios.First().estado == "")
            {
                resp = "El usuario no se encuentra Activo";
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = resp;
                TempData["estado"] = "danger";
                return View("RespuestaConsultaClientes", usuarios);
            }
            usuarios.First().tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            usuario = usuarios.First();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult UpdateCliente(Usuario user)
        {
            string resultado = "", tipoResultado = "";
            string res, tipoRes;
            if (ModelState.IsValid)
            {
                CatalogoUsuarios.GetInstance().ModificarCliente(user,out res, out tipoRes);
                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = res;
                TempData["estado"] = tipoRes;

                return View("RespuestaConsultaClientes", usuarios);

            }

            return View();
        }

        [HttpGet]
        public ActionResult CambiarEstadoCliente(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);
            try
            {
                usuario = usuarios.First();
                usuario.tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion");
                return View(usuario);
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            //CatalogoUsuarios.GetInstance().CambiarEstadoCliente(usuario);

            return View(new Usuario{tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion")});
        }

        [HttpPost]
        public ActionResult ModificarEstadoCliente(Usuario usuario)
        {
            string res, tipoRes;
            string resultado = "", tipoResultado = "";
            CatalogoUsuarios.GetInstance().CambiarEstadoCliente(usuario, out res, out tipoRes);
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);

            TempData["mensaje"] = res;
            TempData["estado"] = tipoRes;
            return View("RespuestaConsultaClientes", usuarios);
        }

        [HttpGet]
        public ActionResult DetallesCliente(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);

            return View("DetallesCliente",usuarios.First());
        }


        [HttpGet]
        public ActionResult VolverDetallesCliente(string iden)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(iden, ref resultado, ref tipoResultado);
            return View("RespuestaConsultaClientes", usuarios);
        }

       
        
        #endregion

    }
}
