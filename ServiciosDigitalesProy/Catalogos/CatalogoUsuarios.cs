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

        public void AdicionarCliente(Usuario cliente, out string resultado, out string tipoResultado)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.AdicionarCliente(cliente,out resultado,out tipoResultado);

        }

        public void ModificarCliente(Usuario cliente, out string res, out string tipoRes)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            usuarioDatos.ModificarCliente(cliente, out res, out tipoRes);
        }

        public void CambiarEstadoCliente(Usuario cliente, out string res, out string tipoRes)
        {
            usuarioDatos.CambiarEstadoCliente(cliente, out res, out tipoRes);
        }
        #endregion

    }


}