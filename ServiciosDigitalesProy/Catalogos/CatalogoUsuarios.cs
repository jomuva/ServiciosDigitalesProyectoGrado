using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Datos;

namespace ServiciosDigitalesProy.Catalogos
{
    public class CatalogoUsuarios
    {
        private static CatalogoUsuarios catalogoUsuarios = null;
        private static UsuarioDatos usuarioDatos = null;

        public CatalogoUsuarios()
        {
            usuarioDatos = new UsuarioDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoUsuarios GetInstance()
        {
            if (catalogoUsuarios == null)
                catalogoUsuarios = new CatalogoUsuarios();
            return catalogoUsuarios;
        }

       
        /// <summary>
        /// Consulta los tipos de identificación traidos desde la clase UsuarioDatos
        /// </summary>
        /// <returns>Lista de Tipos de Identificación</returns>
        public List<TipoIdentificacion> ConsultarTiposIdentificacion()
        {
            return (List<TipoIdentificacion>)usuarioDatos.ConsultarTiposIdentificacion();
        }

        /// <summary>
        /// Consulta los tipos de estado que el usuario puede tener
        /// </summary>
        /// <returns></returns>
        public List<EstadosUsuario> ConsultarEstadosUsuario()
        {
            return (List<EstadosUsuario>)usuarioDatos.ConsultarEstadosUsuario();
        }

        #region Catalogo Clientes

        /// <summary>
        /// recibe el filtro de consulta y lo envía a la clase UsuarioDatos para realizar la busqueda en BD
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Usuario> ConsultarClientes(string ident, ref string resultado, ref string tipoResultado)
        {
            List<Usuario> lista = new List<Usuario>();


            if (ident == ""||ident==null)
                lista = usuarioDatos.ConsultarClientes();
            else if (ident != "" && lista != null)
            {
                lista = usuarioDatos.ConsultarCliente(ident, ref resultado, ref tipoResultado);
            }
            else
                lista = null;

            return lista;
        }


        /// <summary>
        /// envía la información recogida desde el controlador a la clase que conecta con base de datos
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AdicionarCliente(Usuario cliente, out string resultado, out string tipoResultado)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.AdicionarCliente(cliente,out resultado,out tipoResultado);

        }

        /// <summary>
        /// recoge la informacion enviada por el controlador para así complementarla y enviarla a la clase UsuarioDatos y asi enviarla a BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarCliente(Usuario cliente, out string res, out string tipoRes)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.ModificarCliente(cliente, out res, out tipoRes);
        }


        /// <summary>
        /// recoge la informacion necesario desde el controlador para asi enviarlo a la clase UsuarioDatos y actualizarla en BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void CambiarEstadoCliente(Usuario cliente, out string res, out string tipoRes)
        {
            usuarioDatos.CambiarEstadoCliente(cliente, out res, out tipoRes);
        }
        #endregion

        #region Catalogo Empleados
        /// <summary>
        /// recibe el filtro de consulta y lo envía a la clase UsuarioDatos para realizar la busqueda en BD
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Usuario> ConsultarEmpleados(string ident, ref string resultado, ref string tipoResultado)
        {
            List<Usuario> lista = new List<Usuario>();


            if (ident == "" || ident == null)
                lista = usuarioDatos.ConsultarEmpleados();
            else if (ident != "" && lista != null)
            {
                lista = usuarioDatos.ConsultarEmpleado(ident, ref resultado, ref tipoResultado);
            }
            else
                lista = null;

            return lista;
        }


        /// <summary>
        /// envía la información recogida desde el controlador a la clase que conecta con base de datos
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AdicionarEmpleado(Usuario cliente, out string resultado, out string tipoResultado)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.AdicionarEmpleado(cliente, out resultado, out tipoResultado);

        }

        /// <summary>
        /// recoge la informacion enviada por el controlador para así complementarla y enviarla a la clase UsuarioDatos y asi enviarla a BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarEmpleado(Usuario cliente, out string res, out string tipoRes)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.ModificarEmpleado(cliente, out res, out tipoRes);
        }


        /// <summary>
        /// recoge la informacion necesario desde el controlador para asi enviarlo a la clase UsuarioDatos y actualizarla en BD
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void CambiarEstadoEmpleado(Usuario empleado, out string res, out string tipoRes)
        {
            usuarioDatos.CambiarEstadoEmpleado(empleado, out res, out tipoRes);
        }
        #endregion
    }


}