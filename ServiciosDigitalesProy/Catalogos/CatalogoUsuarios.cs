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

       

        public void ModificarUsuario(Usuario usuario) { }

        public void ModificarEstadoUsuario(int id) { }


        /// <summary>
        /// Consulta los tipos de identificación traidos desde la clase UsuarioDatos
        /// </summary>
        /// <returns>Lista de Tipos de Identificación</returns>
        public List<TipoIdentificacion> ConsultarTiposIdentificacion()
        {
            return (List<TipoIdentificacion>)usuarioDatos.ConsultarTiposIdentificacion();
        }

    #region Catalogo Clientes

        


        public List<Usuario> ConsultarClientes(string ident)
        {
            List<Usuario> lista = new List<Usuario>();

            int id = (ident == "") ? 0 : Convert.ToInt32(ident);


            if (id == 0)
                lista = usuarioDatos.ConsultarClientes();
            else if (id != 0 && lista != null)
            {
                lista = usuarioDatos.ConsultarCliente(id);
            }
            else
                lista = null;

            return lista;
        }

        public string AdicionarCliente(Usuario cliente)
        {
            cliente.idRol = 1;
            cliente.idEstado = 1;
            string resp = usuarioDatos.AdicionarCliente(cliente);

            return resp;
        }

    #endregion

    }


}