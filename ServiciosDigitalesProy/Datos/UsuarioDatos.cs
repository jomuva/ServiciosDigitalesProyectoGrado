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

        public List<EstadosUsuario> ConsultarEstadosUsuario()
        {
            var Estados = from Ti in conexion.ESTADO_USUARIO

                             select new EstadosUsuario
                             {
                                 Descripcion = Ti.descripcion,
                                 id = Ti.id_estado

                             };
            return Estados.ToList();
        }


        #region ClientesBd


        /// <summary>
        /// Retorna un cliente en especial segun id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        public List<Usuario> ConsultarCliente(string data)
        {

            int id = 0;
            string resultado;
            List<Usuario> users = new List<Usuario>();

            bool result = int.TryParse(data, out id);
            try
            {
                if (result == true)
                {
                    var telefonoCliente = from TelUsuario in conexion.TELEFONO_USUARIO
                                          join usu in conexion.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.identificacion == id.ToString()
                                          select new TelefonoUsuario
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    List<TelefonoUsuario> Telefonos = telefonoCliente.ToList();

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
                                      estado = es.descripcion,
                                  };

                    List<Usuario> usuario2 = cliente.ToList();
                    usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
                    usuario2.First().TelefonoFijo = Telefonos.Count==1?"":Telefonos[1].numero_telefono;

                    return usuario2;
                }
                else
                {
                    var telefonoCliente = from TelUsuario in conexion.TELEFONO_USUARIO
                                          join usu in conexion.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.nombres == data.ToString()
                                          select new TelefonoUsuario
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    List<TelefonoUsuario> Telefonos = telefonoCliente.ToList();

                    var cliente = from usuario in conexion.USUARIO
                                  join es in conexion.ESTADO_USUARIO
                                   on usuario.id_estado_usuario equals es.id_estado
                                  where usuario.id_rol_usuario == 1 && usuario.nombres == data.ToString()
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

                    List<Usuario> usuario2 = cliente.ToList();
                    usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
                    usuario2.First().TelefonoFijo = Telefonos.Count == 1 ? "" : Telefonos[1].numero_telefono;

                    return usuario2;
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                users.Add(new Usuario { resultado = resultado });
            }

            return users;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Usuario> ConsultarClientes()
        {

            string resultado;
            List<Usuario> lista = new List<Usuario>();
        
            try
            {
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
            catch (Exception ex)
            {
                resultado = ex.Message;
                lista.Add(new Usuario{ resultado = resultado });
            }

            return lista;
        }

        public string AdicionarCliente(Usuario usuario)
        {
            string resultado = "";
            usuario.TelefonoFijo = usuario.TelefonoFijo == null ? "" : usuario.TelefonoFijo;
            var us = from u in conexion.USUARIO
                     where u.usuario_login == usuario.username
                     select u;

            var mail = from m in conexion.USUARIO
                       where m.correo == usuario.email
                       select m;
            if (!us.Any() && !mail.Any())
            {
                try
                {
                    USUARIO USER = new USUARIO();
                    USER.nombres = usuario.nombres;
                    USER.apellidos = usuario.apellidos;
                    USER.correo = usuario.email;
                    USER.direccion = usuario.direccion;
                    USER.sexo = (usuario.sexo).ToString();
                    USER.usuario_login = usuario.username;
                    USER.password = usuario.password;
                    USER.identificacion = usuario.identificacion;
                    USER.id_rol_usuario = usuario.idRol;
                    USER.id_estado_usuario = usuario.idEstado;
                    USER.id_tipo_Identificacion_usuario = usuario.idTipoIdentificacion;

                    conexion.USUARIO.Add(USER);
                    conexion.SaveChanges();

                    var idUsu = from u in conexion.USUARIO
                                where u.identificacion == usuario.identificacion
                                select new Usuario
                                {
                                    id = u.id_usuario
                                };

                    Usuario user = idUsu.First();
                    TELEFONO_USUARIO Telefono = new TELEFONO_USUARIO();
                    Telefono.id_usuario_telefono = user.id;
                    Telefono.numero_telefono = usuario.TelefonoCelular;
                    conexion.TELEFONO_USUARIO.Add(Telefono);
                    conexion.SaveChanges();

                    if (usuario.TelefonoFijo != "")
                    {
                        TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
                        Telefono2.id_usuario_telefono = user.id;
                        Telefono2.numero_telefono = usuario.TelefonoFijo;
                        conexion.TELEFONO_USUARIO.Add(Telefono2);
                        conexion.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    resultado = e.Message;
                }
                resultado = "Cliente registrado correctamente";
            }
            else
            {
                resultado = "Ya existe un usuario registrado con el nombre de usuario o Email ingresado";
            }
            return resultado;
        }


        public string ModificarCliente(Usuario usuario)
        {
            string resultado = "";

                try
                {
                    var queryUSUARIO = from USU in conexion.USUARIO
                                       where USU.identificacion == usuario.identificacion
                                       select USU;
                    foreach (var USUARIO in queryUSUARIO)
                    {
                        USUARIO.apellidos = usuario.apellidos;
                        USUARIO.nombres = usuario.nombres;
                        USUARIO.direccion = usuario.direccion;
                        USUARIO.correo = usuario.email;
                        USUARIO.sexo = usuario.sexo;
                        USUARIO.password = usuario.password;
                    }
                    conexion.SaveChanges();
                }
                catch (Exception e)
                {
                    resultado = e.Message;
                }
                resultado = "Cliente Modificado correctamente";
          
            return resultado;
        }

        public string CambiarEstadoCliente(Usuario usuario)
        {
            string resultado = "";

            try
            {
                var queryUSUARIO = from USU in conexion.USUARIO
                                   where USU.identificacion == usuario.identificacion
                                   select USU;
                foreach (var USUARIO in queryUSUARIO)
                {
                    USUARIO.id_estado_usuario = usuario.idEstado;
                }
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                resultado = e.Message;
            }
            resultado = "Estado del cliente actualizado correctamente";

            return resultado;
        }

        #endregion

    }
}