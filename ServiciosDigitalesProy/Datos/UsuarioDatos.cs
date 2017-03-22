using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;

namespace ServiciosDigitalesProy.Datos
{
    public class UsuarioDatos
    {

        public UsuarioDatos()
        {

        }

        /// <summary>
        /// Objeto conexionque genera conexion a la base de datos
        /// </summary>
        private bdServiciosDigitalesProyEntities conexion = new bdServiciosDigitalesProyEntities();

        /// <summary>
        /// Método de consulta de los tipos de identificacion en BD
        /// </summary>
        public List<TipoIdentificacion> ConsultarTiposIdentificacion()
        {
            var tiposIdent = from Ti in conexion.TIPO_IDENTIFICACION_USUARIO

                             select new TipoIdentificacion
                             {
                                 Descripcion = Ti.descripcion_tipo_identificacion,
                                 id = Ti.id_tipo_identificacion

                             };
            return tiposIdent.ToList();
        }


    #region ClientesBd


        /// <summary>
        /// Retorna un cliente en especial segun id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        public List<Usuario> ConsultarCliente(int id)
        {
            var cliente = from usuario in conexion.USUARIO
                          join es in conexion.ESTADO_USUARIO
                           on usuario.id_estado_usuario equals es.id_estado
                          where usuario.id_rol_usuario == 1 && usuario.identificacion == id.ToString()

                          select new Usuario
                          {
                              nombres = usuario.nombres,
                              apellidos = usuario.apellidos,
                              identificacion = usuario.identificacion,
                              username = usuario.usuario_login,
                              direccion = usuario.direccion,
                              email = usuario.correo,
                              sexo = usuario.sexo,
                              estado = es.descripcion
                          };
            return (List<Usuario>)cliente.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Usuario> ConsultarClientes()
        {
            //var telefono = from tel in conexion.TELEFONO_USUARIO
            //               join telUsu in conexion.USUARIO on tel.id_usuario_telefono equals telUsu.id_usuario
            //               select tel;

            var clientes = from usuario in conexion.USUARIO
                           join es in conexion.ESTADO_USUARIO
                            on usuario.id_estado_usuario equals es.id_estado
                           where usuario.id_rol_usuario == 1

                           select new Usuario
                           {
                               nombres = usuario.nombres,
                               apellidos = usuario.apellidos,
                               identificacion = usuario.identificacion,
                               username = usuario.usuario_login,
                               direccion = usuario.direccion,
                               email = usuario.correo,
                               sexo = usuario.sexo,
                               estado = es.descripcion

                           };
            return (List<Usuario>)clientes.ToList();
        }

        public string AdicionarCliente(Usuario usuario)
        {
            string resultado = "";
            var us = from u in conexion.USUARIO
                     where u.usuario_login == usuario.username
                     select u;
            if (!us.Any())
            {
                try
                {
                    USUARIO USER = new USUARIO();
                    USER.nombres = usuario.nombres;
                    USER.apellidos = usuario.apellidos;
                    USER.correo = usuario.email;
                    USER.direccion = usuario.direccion;
                    USER.sexo = usuario.sexo;
                    USER.usuario_login = usuario.username;
                    USER.password = usuario.password;
                    USER.identificacion = usuario.identificacion;
                    USER.id_rol_usuario = usuario.idRol;
                    USER.id_estado_usuario = usuario.idEstado;
                    USER.id_tipo_Identificacion_usuario = usuario.idTipoIdentificacion;

                    conexion.USUARIO.Add(USER);
                    conexion.SaveChanges();
                }
                catch (Exception e)
                {
                    resultado = e.Message;
                }
                resultado = "Cliente registrado correctamente";
            }
            else
            {
                resultado = "Ya existe un usuario registrado con el nombre de usuario " + usuario.username;
            }
            return resultado;
        }

    #endregion

    }
}