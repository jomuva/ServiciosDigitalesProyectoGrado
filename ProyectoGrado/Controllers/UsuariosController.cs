using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
using ProyectoGrado.Tags;
using Models.Comun;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        #region Clientes
        [HttpGet]
        public ActionResult ConsultarClientes()
        {
            return View("Clientes/ConsultarClientes");
        }

        /// <summary>
        /// Consulta Los clientes segun su identificación.  si el valor es vacio, entonces trae la consulta total
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConsultarClientes(string identificacion)
        {

            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View("Clientes/ConsultarClientes");
            }
            else
            {
                return View("Clientes/RespuestaConsultaClientes", usuarios);
            }
        }

        /// <summary>
        /// Abre el formulario principal para adicionar cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult AdicionarCliente()
        {
            Usuario user = new Usuario();
            user.tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(),"id", "Descripcion");
            return View("Clientes/AdicionarCliente",user);
        }

        /// <summary>
        /// envía el formulario a la logica y posteriormente a la base de datos para adicionar al cliente
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdicionarCliente(Usuario user)
        {
            string resultado = "", tipoResultado = "";

            if (ModelState.IsValid)
            {
                CatalogoUsuarios.GetInstance().AdicionarCliente(user, out resultado, out tipoResultado);

                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("Clientes/RespuestaConsultaClientes", usuarios);
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View("Clientes/AdicionarCliente");
        }

        /// <summary>
        /// Abre el formulario para modificar el cliente con los campos permitidos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModificarCliente(string id)
        {
            string resp;
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);
            if (usuarios.First().estado == "Bloqueado" || usuarios.First().estado == "Eliminado" || usuarios.First().estado == "Inactivo" || usuarios.First().estado == "")
            {
                resp = "El usuario no se encuentra Activo";
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = resp;
                TempData["estado"] = "danger";
                return View("Clientes/RespuestaConsultaClientes", usuarios);
            }
            usuarios.First().tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            usuario = usuarios.First();
            return View("Clientes/ModificarCliente", usuario);
        }

        /// <summary>
        /// Envía el formulario a la lógica de negocio para posteriormente adicionarlo a la base de datos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCliente(Usuario user)
        {
            string resultado = "", tipoResultado = "";
            string res, tipoRes;
            if (ModelState.IsValidField("nombrs")&& ModelState.IsValidField("apellidos")&& ModelState.IsValidField("idTipoIdentificacion")
                && ModelState.IsValidField("direccion")&& ModelState.IsValidField("sexo")&& ModelState.IsValidField("TelefonoFijo")
                && ModelState.IsValidField("TelefonoCelular"))
            {
                CatalogoUsuarios.GetInstance().ModificarCliente(user, out res, out tipoRes);
                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = res;
                TempData["estado"] = tipoRes;

                return View("Clientes/RespuestaConsultaClientes", usuarios);

            }
            TempData["mensaje"] = "Datos incorrectos, verifique la información";
            TempData["estado"] = "danger";
            user.tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            return View("Clientes/ModificarCliente", user);
        }


        ///// <summary>
        ///// Abre la vista principal para cambiar el estado del cliente
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_cambiar_estado_cliente)]
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
                return View("Clientes/CambiarEstadoCliente", usuario);
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            return View("Clientes/CambiarEstadoCliente", new Usuario { tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion") });
        }


        ///// <summary>
        ///// Envía el formulario para cambiar el estado del cliente seleccionado
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <returns></returns>
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
            return View("Clientes/RespuestaConsultaClientes", usuarios);
        }


        /// <summary>
        /// Muestra el detalle de datos de un cliente en específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DetallesCliente(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);

            return View("Clientes/DetallesCliente", usuarios.First());
        }

        /// <summary>
        /// permite volver al menu anterior de consulta general de clientes
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VolverDetallesCliente(string iden)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes(iden, ref resultado, ref tipoResultado);
            return View("Clientes/RespuestaConsultaClientes", usuarios);
        }

        #endregion

        #region Empleados
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.Puede_consultar_empleado)]
        public ActionResult ConsultarEmpleados()
        {
            return View("Empleados/ConsultarEmpleados");
        }

        /// <summary>
        /// Consulta Los clientes segun su identificación.  si el valor es vacio, entonces trae la consulta total
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConsultarEmpleados(string identificacion)
        {

            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View("Empleados/ConsultarEmpleados");
            }
            else
            {
                return View("Empleados/RespuestaConsultaEmpleados", usuarios);
            }
        }

        /// <summary>
        /// Abre el formulario principal para adicionar cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_adicionar_empleado)]
        public ActionResult AdicionarEmpleado()
        {
            Usuario user = new Usuario();
            user.tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            user.Roles = new SelectList(CatalogoUsuarios.GetInstance().ConsultarRolesEmpleado(), "id", "Descripcion");
            return View("Empleados/AdicionarEmpleado", user);
        }

        /// <summary>
        /// envía el formulario a la logica y posteriormente a la base de datos para adicionar al cliente
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdicionarEmpleado(Usuario user)
        {
            string resultado = "", tipoResultado = "";

            if (ModelState.IsValid)
            {
                CatalogoUsuarios.GetInstance().AdicionarEmpleado(user, out resultado, out tipoResultado);

                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados("", ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("Empleados/RespuestaConsultaEmpleados", usuarios);
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View("Empleados/AdicionarEmpleado");
        }

        /// <summary>
        /// Abre el formulario para modificar el cliente con los campos permitidos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_editar_empleado)]
        public ActionResult ModificarEmpleado(string id)
        {
            string resp;
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados(id, ref resultado, ref tipoResultado);
            if (usuarios.First().estado == "Bloqueado" || usuarios.First().estado == "Eliminado" || usuarios.First().estado == "Inactivo" || usuarios.First().estado == "")
            {
                resp = "El usuario no se encuentra Activo";
                usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = resp;
                TempData["estado"] = "danger";
                return View("Empleados/RespuestaConsultaEmpleados", usuarios);
            }
            usuarios.First().tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            usuarios.First().Roles = new SelectList(CatalogoUsuarios.GetInstance().ConsultarRolesEmpleado(), "id", "Descripcion");
            usuario = usuarios.First();
            return View("Empleados/ModificarEmpleado", usuario);
        }

        /// <summary>
        /// Envía el formulario a la lógica de negocio para posteriormente adicionarlo a la base de datos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateEmpleado(Usuario user)
        {
            string resultado = "", tipoResultado = "";
            string res, tipoRes;
            if (ModelState.IsValidField("nombrs") && ModelState.IsValidField("apellidos") && ModelState.IsValidField("idTipoIdentificacion")
               && ModelState.IsValidField("direccion") && ModelState.IsValidField("sexo") && ModelState.IsValidField("TelefonoFijo")
               && ModelState.IsValidField("TelefonoCelular"))
            {
                CatalogoUsuarios.GetInstance().ModificarEmpleado(user, out res, out tipoRes);
                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = res;
                TempData["estado"] = tipoRes;

                return View("Empleados/RespuestaConsultaEmpleados", usuarios);

            }

            TempData["mensaje"] = "Datos incorrectos, verifique la información";
            TempData["estado"] = "danger";
            user.tiposIdentificacion = new SelectList(CatalogoUsuarios.GetInstance().ConsultarTiposIdentificacion(), "id", "Descripcion");
            user.Roles = new SelectList(CatalogoUsuarios.GetInstance().ConsultarRolesEmpleado(), "id", "Descripcion");
            return View("Empleados/ModificarEmpleado", user);
        }


        /// <summary>
        /// Abre la vista principal para cambiar el estado del cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CambiarEstadoEmpleado(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            Usuario usuario;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados(id, ref resultado, ref tipoResultado);
            try
            {
                usuario = usuarios.First();
                usuario.tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion");
                return View("Empleados/CambiarEstadoEmpleado", usuario);
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            return View("Empleados/CambiarEstadoEmpleado", new Usuario { tiposEstado = new SelectList(CatalogoUsuarios.GetInstance().ConsultarEstadosUsuario(), "id", "Descripcion") });
        }


        /// <summary>
        /// Envía el formulario para cambiar el estado del cliente seleccionado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModificarEstadoEmpleado(Usuario usuario)
        {
            string res, tipoRes;
            string resultado = "", tipoResultado = "";
            CatalogoUsuarios.GetInstance().CambiarEstadoEmpleado(usuario, out res, out tipoRes);
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);

            TempData["mensaje"] = res;
            TempData["estado"] = tipoRes;
            return View("Empleados/RespuestaConsultaEmpleados", usuarios);
        }


        /// <summary>
        /// Muestra el detalle de datos de un cliente en específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DetallesEmpleado(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados(id, ref resultado, ref tipoResultado);

            return View("Empleados/DetallesEmpleado", usuarios.First());
        }

        /// <summary>
        /// permite volver al menu anterior de consulta general de clientes
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VolverDetallesEmpleado(string iden)
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> usuarios;
            usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados(iden, ref resultado, ref tipoResultado);
            return View("Empleados/RespuestaConsultaEmpleados", usuarios);
        }
        #endregion
    }
}
