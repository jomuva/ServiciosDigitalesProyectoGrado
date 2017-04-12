using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helper;
namespace Persistencia.UsuarioDatos
{
    public class UsuarioDatos
    {
        private conexion conexion  = new conexion();
        public UsuarioDatos()
        {

        }

      
        /// <summary>
        /// Método de consulta de los tipos de identificacion en BD
        /// </summary>
        public object ConsultarTiposIdentificacion()
        {
            var tiposIdent = from Ti in conexion.conexiones.TIPO_IDENTIFICACION_USUARIO

                             select new 
                             {
                                 Descripcion = Ti.descripcion_tipo_identificacion,
                                 id = Ti.id_tipo_identificacion

                             };
            return tiposIdent.ToList();
        }


        /// <summary>
        /// Consulta los estados de un usuario en BD
        /// </summary>
        /// <returns></returns>
        public object ConsultarEstadosUsuario()
        {
            var Estados = from Ti in conexion.conexiones.ESTADO_USUARIO

                          select new 
                          {
                              Descripcion = Ti.descripcion,
                              id = Ti.id_estado

                          };
            return Estados.ToList();
        }

        ///// <summary>
        ///// Consulta los roles de un empleado en BD
        ///// </summary>
        ///// <returns></returns>

    #region Autenticacion
        
            /// <summary>
            /// Valida que el usuario haya enviado correctamente los datos de logeo y devuelve su identificacion
            /// </summary>
            /// <param name="username"></param>
            /// <param name="passwd"></param>
            /// <param name="resultado"></param>
            /// <param name="tipoResultado"></param>
            /// <returns></returns>
        public object ValidarAutenticacionLogin(string username,string passwd,ref string resultado, ref string tipoResultado)

        {
            object usuario = null;
            try
            {

                //var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
                usuario = conexion.conexiones.ValidarAutenticacionLogin(username, passwd).ToList();
                //var mail = from m in conexion.conexiones.USUARIO
                //                where m.usuario_login == username
                //                select m;
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            return usuario;
        }

        public void Autenticarse(string id,string username, ref string resultado, ref string tipoResultado)
        {
            SessionHelper.AddUserToSession(id,username);
            resultado = "Inicio de sesion correcto";
            tipoResultado = "success";
            

        }

        /// <summary>
        /// CONSULTAR PERMISOS POR ROL DE USUARIO RETORNANDO LOS PERMISOS Y EL ID A LOS QUE NO TIENE ACCESO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarPermisosXUsuario(string id, ref string resultado, ref string tipoResultado)
        {
            object permisos = null;
            try
            {
               permisos = conexion.conexiones.ConsultarPermisosXUsuario(id).ToList();
            }
            catch(Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            return permisos;
        }


    #endregion
        #region ClientesBd


        ///// <summary>
        ///// Retorna un cliente en especial segun id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>Usuario</returns>
        public object ConsultarCliente(string data, ref object telefonos, ref string resultado, ref string tipoResultado)
        {
            

            int id = 0;
            object users = null;
            bool result = int.TryParse(data, out id);
            try
            { 
                if (result == true)
                {
                    var telefonoCliente = from TelUsuario in conexion.conexiones.TELEFONO_USUARIO
                                          join usu in conexion.conexiones.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.identificacion == id.ToString()
                                          select new 
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    telefonos = telefonoCliente.ToList();

                    var cliente = from usuario in conexion.conexiones.USUARIO
                                  join es in conexion.conexiones.ESTADO_USUARIO
                                   on usuario.id_estado_usuario equals es.id_estado
                                  where usuario.id_rol_usuario == 1 && usuario.identificacion == id.ToString()
                                  select new 
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


                    if (cliente.ToList().Count == 0)
                    {
                        resultado = "El cliente no existe en la base de datos";
                        tipoResultado = "danger";
                    }
                    else
                    {
                        resultado = "Consulta Exitosa";
                        tipoResultado = "info";
                    }

                    return cliente.ToList();
                }
                else
                {
                    var telefonoCliente = from TelUsuario in conexion.conexiones.TELEFONO_USUARIO
                                          join usu in conexion.conexiones.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.nombres == data.ToString()
                                          select new 
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    telefonos = telefonoCliente.ToList();

                    var cliente = from usuario in conexion.conexiones.USUARIO
                                  join es in conexion.conexiones.ESTADO_USUARIO
                                   on usuario.id_estado_usuario equals es.id_estado
                                  where usuario.id_rol_usuario == 1 && usuario.nombres == data.ToString()
                                  select new 
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

                    
                    if (cliente.ToList().Count == 0)
                    {
                        resultado = "El cliente no existe en la base de datos";
                        tipoResultado = "danger";
                    }else
                    {
                        resultado = "Consulta Exitosa";
                        tipoResultado = "info";
                    }
                    return cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }


            return users;

        }

        ///// <summary>
        ///// Consulta el total de clientes que hay en BD
        ///// </summary>
        ///// <returns>Lista de Clientes</returns>
        public object ConsultarClientes()
        {

            string resultado;
            object lista = null;
            try
            {
                var clientes = from usuario in conexion.conexiones.USUARIO
                               join es in conexion.conexiones.ESTADO_USUARIO
                                on usuario.id_estado_usuario equals es.id_estado
                               where usuario.id_rol_usuario == 1

                               select new 
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

                return clientes.ToList();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return lista;
        }


        ///// <summary>
        ///// Adiciona un cliente a la base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="resultado"></param>
        ///// <param name="tipoResultado"></param>
        public void AdicionarCliente(
                string TelefonoFijo, string TelefonoCelular, string username, string email, 
                string identificacion, string nombres, string apellidos, string direccion, 
                string sexo, string password, int idRol, int idEstado, int idTipoIdentificacion,
                out string resultado, out string tipoResultado)
        {
            TelefonoFijo = TelefonoFijo == null ? "" : TelefonoFijo;
            var us = from u in conexion.conexiones.USUARIO
                     where u.usuario_login == username
                     select u;

            var mail = from m in conexion.conexiones.USUARIO
                       where m.correo == email
                       select m;

            var identificac = from m in conexion.conexiones.USUARIO
                              where m.identificacion == identificacion
                              select m;
            if (!us.Any() && !mail.Any() && !identificac.Any())
            {
                try
                {
                    conexion.conexiones.AgregarUsuario( idTipoIdentificacion,idEstado,idRol,
                                                        identificacion,apellidos,nombres,
                                                        direccion,email,sexo,username,password);
                    conexion.conexiones.SaveChanges();

                    var idUsu = from u in conexion.conexiones.USUARIO
                                where u.identificacion == identificacion
                                select new 
                                {
                                    id = u.id_usuario
                                };

                    TELEFONO_USUARIO Telefono = new TELEFONO_USUARIO();
                    Telefono.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                    Telefono.numero_telefono = TelefonoCelular;
                    conexion.conexiones.TELEFONO_USUARIO.Add(Telefono);
                    conexion.conexiones.SaveChanges();

                    if (TelefonoFijo != "")
                    {
                        TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
                        Telefono2.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                        Telefono2.numero_telefono = TelefonoFijo;
                        conexion.conexiones.TELEFONO_USUARIO.Add(Telefono2);
                        conexion.conexiones.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    resultado = e.Message;
                }
                resultado = "Cliente registrado correctamente";
                tipoResultado = "success";
            }
            else
            {
                resultado = "Ya existe un usuario registrado con el nombre de usuario, email o identificación ingresado";
                tipoResultado = "danger";
            }
        }

        ///// <summary>
        ///// Modifica un cliente en específico y lo actualiza en base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        public void ModificarCliente(
                    string TelefonoFijo, string TelefonoCelular, string username,
                    string email, string identificacion, string nombres, string apellidos, 
                    string direccion, string sexo, string password, int idTipoIdentificacion, 
                    out string res, out string tipoRes)
        {

            try
            {
                var queryUSUARIO = from USU in conexion.conexiones.USUARIO
                                   where USU.identificacion == identificacion
                                   select USU;
                foreach (var USUARIO in queryUSUARIO)
                {
                    USUARIO.apellidos = apellidos;
                    USUARIO.nombres = nombres;
                    USUARIO.direccion = direccion;
                    USUARIO.correo = email;
                    USUARIO.sexo = sexo;
                    USUARIO.password = password;
                }
                conexion.conexiones.SaveChanges();

                var idUsu = from u in conexion.conexiones.USUARIO
                            where u.identificacion == identificacion
                            select new 
                            {
                                id = u.id_usuario
                            };

                var queryTelefono = from tel in conexion.conexiones.TELEFONO_USUARIO
                                    join usu in conexion.conexiones.USUARIO
                                    on tel.id_usuario_telefono equals usu.id_usuario
                                    where usu.identificacion == identificacion
                                    select tel;
                int i = 0;
                foreach (var tele in queryTelefono)
                {
                    tele.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id); 
                    if (i == 0)
                        tele.numero_telefono = TelefonoCelular;
                    else
                    {
                        tele.numero_telefono = TelefonoFijo;
                    }
                    i++;
                }

                conexion.conexiones.SaveChanges();
                res = "Cliente Modificado correctamente";
                tipoRes = "success";
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }

        }

        ///// <summary>
        ///// modifica el estado del cliente solicitado en base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        public void CambiarEstadoCliente(int idEstado, string identificacion, out string res, out string tipoRes)
        {

            try
            {
                var queryUSUARIO = from USU in conexion.conexiones.USUARIO
                                   where USU.identificacion == identificacion
                                   select USU;
                foreach (var USUARIO in queryUSUARIO)
                {
                    USUARIO.id_estado_usuario = idEstado;
                }
                if (queryUSUARIO.Count() == 0)
                {
                    res = "La Operación no Produjo ningun resultado";
                    tipoRes = "danger";
                }
                else
                {
                    res = "Estado del cliente actualizado correctamente";
                    tipoRes = "success";
                }
                conexion.conexiones.SaveChanges();
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }


        }

        #endregion

        #region EmpleadosBd

        public object ConsultarRolEmpleado()
        {
            var Roles = from Ti in conexion.conexiones.ROL
                        where Ti.id_rol != 1

                        select new
                        {
                            Descripcion = Ti.descripcion,
                            id = Ti.id_rol

                        };
            return Roles.ToList();
        }



        /// <summary>
        /// Retorna un Empleado en especial segun id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        public object ConsultarEmpleado(string data, ref object telefonos, ref string resultado, ref string tipoResultado)
        {

            int id = 0;
            object users = null;

            bool result = int.TryParse(data, out id);
            try
            {
                if (result == true)
                {
                    var telefonoEmpleado = from TelUsuario in conexion.conexiones.TELEFONO_USUARIO
                                           join usu in conexion.conexiones.USUARIO
                                             on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                           where usu.identificacion == id.ToString()
                                           select new 
                                           {
                                               numero_telefono = TelUsuario.numero_telefono,
                                               id_usuario_telefono = usu.id_usuario,
                                           };
                    telefonos = telefonoEmpleado.ToList();

                    var Empleado = from usuario in conexion.conexiones.USUARIO
                                   join es in conexion.conexiones.ESTADO_USUARIO
                                    on usuario.id_estado_usuario equals es.id_estado
                                   join roles in conexion.conexiones.ROL
                                   on usuario.id_rol_usuario equals roles.id_rol
                                   where (usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4) && usuario.identificacion == id.ToString()
                                   select new 
                                   {
                                       nombres = usuario.nombres,
                                       apellidos = usuario.apellidos,
                                       identificacion = usuario.identificacion,
                                       username = usuario.usuario_login,
                                       direccion = usuario.direccion,
                                       email = usuario.correo,
                                       sexo = usuario.sexo,
                                       estado = es.descripcion,
                                       Rol = roles.descripcion
                                   };

                    if (Empleado.ToList().Count == 0)
                    {
                        resultado = "El empleado no existe en la base de datos";
                        tipoResultado = "danger";
                    }
                    else
                    {
                        resultado = "Consulta Exitosa";
                        tipoResultado = "info";
                    }

                    return Empleado.ToList();
                }
                else
                {
                    var telefonoEmpleado = from TelUsuario in conexion.conexiones.TELEFONO_USUARIO
                                           join usu in conexion.conexiones.USUARIO
                                             on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                           where usu.nombres == data.ToString()
                                           select new 
                                           {
                                               numero_telefono = TelUsuario.numero_telefono,
                                               id_usuario_telefono = usu.id_usuario,
                                           };
                    telefonos = telefonoEmpleado.ToList();

                    var empleado = from usuario in conexion.conexiones.USUARIO
                                   join es in conexion.conexiones.ESTADO_USUARIO
                                    on usuario.id_estado_usuario equals es.id_estado
                                   join roles in conexion.conexiones.ROL
                                   on usuario.id_rol_usuario equals roles.id_rol
                                   where (usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4) && usuario.nombres == data.ToString()
                                   select new 
                                   {
                                       nombres = usuario.nombres,
                                       apellidos = usuario.apellidos,
                                       identificacion = usuario.identificacion,
                                       username = usuario.usuario_login,
                                       direccion = usuario.direccion,
                                       email = usuario.correo,
                                       sexo = usuario.sexo,
                                       estado = es.descripcion,
                                       Rol = roles.descripcion
                                   };

                    if (empleado.ToList().Count == 0)
                    {
                        resultado = "El empleado no existe en la base de datos";
                        tipoResultado = "danger";
                    }
                    else
                    {
                        resultado = "Consulta Exitosa";
                        tipoResultado = "info";
                    }

                    return empleado.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return users;

        }

        /// <summary>
        /// Consulta el total de empleados que hay en BD
        /// </summary>
        /// <returns>Lista de Empleados</returns>
        public object ConsultarEmpleados()
        {

            string resultado;
            object lista = null;
            try
            {
                var Empleados = from usuario in conexion.conexiones.USUARIO
                                join es in conexion.conexiones.ESTADO_USUARIO
                                 on usuario.id_estado_usuario equals es.id_estado
                                join roles in conexion.conexiones.ROL
                                 on usuario.id_rol_usuario equals roles.id_rol
                                where usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4

                                select new 
                                {
                                    nombres = usuario.nombres,
                                    apellidos = usuario.apellidos,
                                    identificacion = usuario.identificacion,
                                    username = usuario.usuario_login,
                                    direccion = usuario.direccion,
                                    email = usuario.correo,
                                    sexo = usuario.sexo,
                                    estado = es.descripcion,
                                    Rol = roles.descripcion
                                };

                return Empleados.ToList();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return lista;
        }


        /// <summary>
        /// Adiciona un empleado a la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AdicionarEmpleado(
                            string TelefonoFijo, string TelefonoCelular, string username, string email,
                            string identificacion, string nombres, string apellidos, string direccion,
                            string sexo, string password, int idRol, int idEstado, int idTipoIdentificacion,
                            out string resultado, out string tipoResultado)
        {
            TelefonoFijo = TelefonoFijo == null ? "" : TelefonoFijo;
            var us = from u in conexion.conexiones.USUARIO
                     where u.usuario_login == username
                     select u;

            var mail = from m in conexion.conexiones.USUARIO
                       where m.correo == email
                       select m;

            var identificac = from m in conexion.conexiones.USUARIO
                              where m.identificacion == identificacion
                              select m;
            if (!us.Any() && !mail.Any() && !identificac.Any())
            {
                try
                {
                    //USUARIO USER = new USUARIO();
                    //USER.nombres = nombres;
                    //USER.apellidos = apellidos;
                    //USER.correo = email;
                    //USER.direccion = direccion;
                    //USER.sexo = sexo;
                    //USER.usuario_login = username;
                    //USER.password = password;
                    //USER.identificacion = identificacion;
                    //USER.id_rol_usuario = idRol;
                    //USER.id_estado_usuario = idEstado;
                    //USER.id_tipo_Identificacion_usuario = idTipoIdentificacion;

                    //conexion.conexiones.USUARIO.Add(USER);
                    conexion.conexiones.AgregarUsuario(idTipoIdentificacion, idEstado, idRol,
                                                        identificacion, apellidos, nombres,
                                                        direccion, email, sexo, username, password);
                    conexion.conexiones.SaveChanges();

                    var idUsu = from u in conexion.conexiones.USUARIO
                                where u.identificacion == identificacion
                                select new 
                                {
                                    id = u.id_usuario
                                };

                    TELEFONO_USUARIO Telefono = new TELEFONO_USUARIO();
                    Telefono.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                    Telefono.numero_telefono = TelefonoCelular;
                    conexion.conexiones.TELEFONO_USUARIO.Add(Telefono);
                    conexion.conexiones.SaveChanges();

                    if (TelefonoFijo != "")
                    {
                        TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
                        Telefono2.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                        Telefono2.numero_telefono = TelefonoFijo;
                        conexion.conexiones.TELEFONO_USUARIO.Add(Telefono2);
                        conexion.conexiones.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    resultado = e.Message;
                }
                resultado = "Empleado registrado correctamente";
                tipoResultado = "success";
            }
            else
            {
                resultado = "Ya existe un empleado registrado con el nombre de usuario, email o identificación ingresado";
                tipoResultado = "danger";
            }
        }

        /// <summary>
        /// Modifica un empleado en específico y lo actualiza en base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarEmpleado(
                                     string TelefonoFijo, string TelefonoCelular, string username,
                                     string email, string identificacion, string nombres, string apellidos,
                                     string direccion, string sexo, string password, int idTipoIdentificacion, int idRol,
                                     out string res, out string tipoRes)
        {

            try
            {
                var queryUSUARIO = from USU in conexion.conexiones.USUARIO
                                   where USU.identificacion == identificacion
                                   select USU;
                foreach (var USUARIO in queryUSUARIO)
                {
                    USUARIO.apellidos = apellidos;
                    USUARIO.nombres = nombres;
                    USUARIO.direccion = direccion;
                    USUARIO.correo = email;
                    USUARIO.sexo = sexo;
                    USUARIO.password = password;
                    USUARIO.id_rol_usuario = idRol;

                }
                conexion.conexiones.SaveChanges();

                var idUsu = from u in conexion.conexiones.USUARIO
                            where u.identificacion == identificacion
                            select new 
                            {
                                id = u.id_usuario
                            };

                var queryTelefono = from tel in conexion.conexiones.TELEFONO_USUARIO
                                    join usu in conexion.conexiones.USUARIO
                                    on tel.id_usuario_telefono equals usu.id_usuario
                                    where usu.identificacion == identificacion
                                    select tel;
                int i = 0;
                foreach (var tele in queryTelefono)
                {
                    tele.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                    if (i == 0)
                        tele.numero_telefono = TelefonoCelular;
                    else
                    {
                        tele.numero_telefono = TelefonoFijo;
                    }
                    i++;
                }

                conexion.conexiones.SaveChanges();

                if (TelefonoFijo != "")
                {
                    TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
                    Telefono2.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                    Telefono2.numero_telefono = TelefonoFijo;
                    conexion.conexiones.TELEFONO_USUARIO.Add(Telefono2);
                    conexion.conexiones.SaveChanges();
                }
                res = "Empleado Modificado correctamente";
                tipoRes = "success";
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }

        }

        /// <summary>
        /// modifica el estado del Empleado solicitado en base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void CambiarEstadoEmpleado(string identificacion, int idEstado, out string res, out string tipoRes)
        {

            try
            {
                var queryUSUARIO = from USU in conexion.conexiones.USUARIO
                                   where USU.identificacion == identificacion
                                   select USU;
                foreach (var USUARIO in queryUSUARIO)
                {
                    USUARIO.id_estado_usuario = idEstado;
                }
                if (queryUSUARIO.Count() == 0)
                {
                    res = "La Operación no Produjo ningun resultado";
                    tipoRes = "danger";
                }
                else
                {
                    res = "Estado del Empleado actualizado correctamente";
                    tipoRes = "success";
                }
                conexion.conexiones.SaveChanges();
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }


        }
        #endregion
    }
}