using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.UsuarioDatos
{
    public class UsuarioDatos
    {

        public UsuarioDatos()
        {

        }

        /// <summary>
        /// Objeto conexionque genera conexion a la base de datos
        /// </summary>
        private bdServiciosDigitalesProyEntities1 conexion = new bdServiciosDigitalesProyEntities1();

        /// <summary>
        /// Método de consulta de los tipos de identificacion en BD
        /// </summary>
        public object ConsultarTiposIdentificacion()
        {
            var tiposIdent = from Ti in conexion.TIPO_IDENTIFICACION_USUARIO

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
            var Estados = from Ti in conexion.ESTADO_USUARIO

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
        public object ConsultarRolEmpleado()
        {
            var Roles = from Ti in conexion.ROL
                        where Ti.id_rol != 1

                        select new 
                        {
                            Descripcion = Ti.descripcion,
                            id = Ti.id_rol

                        };
            return Roles.ToList();
        }


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
                    var telefonoCliente = from TelUsuario in conexion.TELEFONO_USUARIO
                                          join usu in conexion.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.identificacion == id.ToString()
                                          select new 
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    telefonos = telefonoCliente.ToList();

                    var cliente = from usuario in conexion.USUARIO
                                  join es in conexion.ESTADO_USUARIO
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

                    //List<Usuario> usuario2 = cliente.ToList();
                    //usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
                    //usuario2.First().TelefonoFijo = Telefonos.Count == 1 ? "" : Telefonos[1].numero_telefono;

                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";

                    return cliente.ToList();
                }
                else
                {
                    var telefonoCliente = from TelUsuario in conexion.TELEFONO_USUARIO
                                          join usu in conexion.USUARIO
                                            on TelUsuario.id_usuario_telefono equals usu.id_usuario
                                          where usu.nombres == data.ToString()
                                          select new 
                                          {
                                              numero_telefono = TelUsuario.numero_telefono,
                                              id_usuario_telefono = usu.id_usuario,
                                          };
                    telefonos = telefonoCliente.ToList();

                    var cliente = from usuario in conexion.USUARIO
                                  join es in conexion.ESTADO_USUARIO
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

                    //List<Usuario> usuario2 = cliente.ToList();
                    //usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
                    //usuario2.First().TelefonoFijo = Telefonos.Count == 1 ? "" : Telefonos[1].numero_telefono;

                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";

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
                var clientes = from usuario in conexion.USUARIO
                               join es in conexion.ESTADO_USUARIO
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
            var us = from u in conexion.USUARIO
                     where u.usuario_login == username
                     select u;

            var mail = from m in conexion.USUARIO
                       where m.correo == email
                       select m;

            var identificac = from m in conexion.USUARIO
                              where m.identificacion == identificacion
                              select m;
            if (!us.Any() && !mail.Any() && !identificac.Any())
            {
                try
                {
                    USUARIO USER = new USUARIO();
                    USER.nombres = nombres;
                    USER.apellidos = apellidos;
                    USER.correo = email;
                    USER.direccion = direccion;
                    USER.sexo = sexo;
                    USER.usuario_login = username;
                    USER.password = password;
                    USER.identificacion = identificacion;
                    USER.id_rol_usuario = idRol;
                    USER.id_estado_usuario = idEstado;
                    USER.id_tipo_Identificacion_usuario = idTipoIdentificacion;

                    conexion.USUARIO.Add(USER);
                    conexion.SaveChanges();

                    var idUsu = from u in conexion.USUARIO
                                where u.identificacion == identificacion
                                select new 
                                {
                                    id = u.id_usuario
                                };

                    TELEFONO_USUARIO Telefono = new TELEFONO_USUARIO();
                    Telefono.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                    Telefono.numero_telefono = TelefonoCelular;
                    conexion.TELEFONO_USUARIO.Add(Telefono);
                    conexion.SaveChanges();

                    if (TelefonoFijo != "")
                    {
                        TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
                        Telefono2.id_usuario_telefono = Convert.ToInt32(idUsu.FirstOrDefault().id);
                        Telefono2.numero_telefono = TelefonoFijo;
                        conexion.TELEFONO_USUARIO.Add(Telefono2);
                        conexion.SaveChanges();
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
        //public void ModificarCliente(Usuario usuario, out string res, out string tipoRes)
        //{

        //    try
        //    {
        //        var queryUSUARIO = from USU in conexion.USUARIO
        //                           where USU.identificacion == usuario.identificacion
        //                           select USU;
        //        foreach (var USUARIO in queryUSUARIO)
        //        {
        //            USUARIO.apellidos = usuario.apellidos;
        //            USUARIO.nombres = usuario.nombres;
        //            USUARIO.direccion = usuario.direccion;
        //            USUARIO.correo = usuario.email;
        //            USUARIO.sexo = usuario.sexo;
        //            USUARIO.password = usuario.password;
        //        }
        //        conexion.SaveChanges();

        //        var idUsu = from u in conexion.USUARIO
        //                    where u.identificacion == usuario.identificacion
        //                    select new Usuario
        //                    {
        //                        id = u.id_usuario
        //                    };

        //        Usuario user = idUsu.First();
        //        var queryTelefono = from tel in conexion.TELEFONO_USUARIO
        //                            join usu in conexion.USUARIO
        //                            on tel.id_usuario_telefono equals usu.id_usuario
        //                            where usu.identificacion == usuario.identificacion
        //                            select tel;
        //        int i = 0;
        //        foreach (var tele in queryTelefono)
        //        {
        //            tele.id_usuario_telefono = user.id;
        //            if(i==0)
        //                 tele.numero_telefono = usuario.TelefonoCelular;
        //            else
        //            {
        //                tele.numero_telefono = usuario.TelefonoFijo;
        //            }
        //            i++;
        //        }

        //        conexion.SaveChanges();
        //        res = "Cliente Modificado correctamente";
        //        tipoRes = "success";
        //    }
        //    catch (Exception e)
        //    {
        //        res = e.Message;
        //        tipoRes = "danger";
        //    }

        //}

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
                var queryUSUARIO = from USU in conexion.USUARIO
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
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }


        }

        #endregion

        //#region EmpleadosBd

        ///// <summary>
        ///// Retorna un Empleado en especial segun id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>Usuario</returns>
        //public List<Usuario> ConsultarEmpleado(string data, ref string resultado, ref string tipoResultado)
        //{

        //    int id = 0;
        //    List<Usuario> users = new List<Usuario>();

        //    bool result = int.TryParse(data, out id);
        //    try
        //    {
        //        if (result == true)
        //        {
        //            var telefonoEmpleado = from TelUsuario in conexion.TELEFONO_USUARIO
        //                                  join usu in conexion.USUARIO
        //                                    on TelUsuario.id_usuario_telefono equals usu.id_usuario
        //                                  where usu.identificacion == id.ToString()
        //                                  select new TelefonoUsuario
        //                                  {
        //                                      numero_telefono = TelUsuario.numero_telefono,
        //                                      id_usuario_telefono = usu.id_usuario,
        //                                  };
        //            List<TelefonoUsuario> Telefonos = telefonoEmpleado.ToList();

        //            var Empleado = from usuario in conexion.USUARIO
        //                          join es in conexion.ESTADO_USUARIO
        //                           on usuario.id_estado_usuario equals es.id_estado
        //                             join roles in conexion.ROL
        //                             on usuario.id_rol_usuario equals roles.id_rol
        //                           where (usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4) && usuario.identificacion == id.ToString()
        //                          select new Usuario
        //                          {
        //                              nombres = usuario.nombres,
        //                              apellidos = usuario.apellidos,
        //                              identificacion = usuario.identificacion,
        //                              username = usuario.usuario_login,
        //                              direccion = usuario.direccion,
        //                              email = usuario.correo,
        //                              sexo = usuario.sexo,
        //                              estado = es.descripcion,
        //                              Rol = roles.descripcion
        //                          };

        //            List<Usuario> usuario2 = Empleado.ToList();
        //            usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
        //            usuario2.First().TelefonoFijo = Telefonos.Count == 1 ? "" : Telefonos[1].numero_telefono;

        //            resultado = "Consulta Exitosa";
        //            tipoResultado = "info";

        //            return usuario2;
        //        }
        //        else
        //        {
        //            var telefonoEmpleado = from TelUsuario in conexion.TELEFONO_USUARIO
        //                                  join usu in conexion.USUARIO
        //                                    on TelUsuario.id_usuario_telefono equals usu.id_usuario
        //                                  where usu.nombres == data.ToString()
        //                                  select new TelefonoUsuario
        //                                  {
        //                                      numero_telefono = TelUsuario.numero_telefono,
        //                                      id_usuario_telefono = usu.id_usuario,
        //                                  };
        //            List<TelefonoUsuario> Telefonos = telefonoEmpleado.ToList();

        //            var empleado = from usuario in conexion.USUARIO
        //                          join es in conexion.ESTADO_USUARIO
        //                           on usuario.id_estado_usuario equals es.id_estado
        //                             join roles in conexion.ROL
        //                             on usuario.id_rol_usuario equals roles.id_rol
        //                           where (usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4) && usuario.nombres == data.ToString()
        //                          select new Usuario
        //                          {
        //                              nombres = usuario.nombres,
        //                              apellidos = usuario.apellidos,
        //                              identificacion = usuario.identificacion,
        //                              username = usuario.usuario_login,
        //                              direccion = usuario.direccion,
        //                              email = usuario.correo,
        //                              sexo = usuario.sexo,
        //                              estado = es.descripcion,
        //                              Rol = roles.descripcion
        //                          };

        //            List<Usuario> usuario2 = empleado.ToList();
        //            usuario2.First().TelefonoCelular = Telefonos[0].numero_telefono;
        //            usuario2.First().TelefonoFijo = Telefonos.Count == 1 ? "" : Telefonos[1].numero_telefono;

        //            resultado = "Consulta Exitosa";
        //            tipoResultado = "info";

        //            return usuario2;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = ex.Message;
        //        tipoResultado = "danger";
        //    }

        //    return users;

        //}

        ///// <summary>
        ///// Consulta el total de empleados que hay en BD
        ///// </summary>
        ///// <returns>Lista de Empleados</returns>
        //public List<Usuario> ConsultarEmpleados()
        //{

        //    string resultado;
        //    List<Usuario> lista = new List<Usuario>();

        //    try
        //    {
        //        var Empleados = from usuario in conexion.USUARIO
        //                       join es in conexion.ESTADO_USUARIO
        //                        on usuario.id_estado_usuario equals es.id_estado
        //                       join roles in conexion.ROL
        //                        on usuario.id_rol_usuario equals roles.id_rol 
        //                       where usuario.id_rol_usuario == 2 || usuario.id_rol_usuario == 3 || usuario.id_rol_usuario == 4

        //                       select new Usuario
        //                       {
        //                           nombres = usuario.nombres,
        //                           apellidos = usuario.apellidos,
        //                           identificacion = usuario.identificacion,
        //                           username = usuario.usuario_login,
        //                           direccion = usuario.direccion,
        //                           email = usuario.correo,
        //                           sexo = usuario.sexo,
        //                           estado = es.descripcion,
        //                           Rol = roles.descripcion
        //                       };

        //        return (List<Usuario>)Empleados.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = ex.Message;
        //        //lista.Add(new Usuario { resultado = resultado });
        //    }

        //    return lista;
        //}


        ///// <summary>
        ///// Adiciona un empleado a la base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="resultado"></param>
        ///// <param name="tipoResultado"></param>
        //public void AdicionarEmpleado(Usuario usuario, out string resultado, out string tipoResultado)
        //{
        //    usuario.TelefonoFijo = usuario.TelefonoFijo == null ? "" : usuario.TelefonoFijo;
        //    var us = from u in conexion.USUARIO
        //             where u.usuario_login == usuario.username
        //             select u;

        //    var mail = from m in conexion.USUARIO
        //               where m.correo == usuario.email
        //               select m;

        //    var identificac = from m in conexion.USUARIO
        //                      where m.identificacion == usuario.identificacion
        //                      select m;
        //    if (!us.Any() && !mail.Any() && !identificac.Any())
        //    {
        //        try
        //        {
        //            USUARIO USER = new USUARIO();
        //            USER.nombres = usuario.nombres;
        //            USER.apellidos = usuario.apellidos;
        //            USER.correo = usuario.email;
        //            USER.direccion = usuario.direccion;
        //            USER.sexo = (usuario.sexo).ToString();
        //            USER.usuario_login = usuario.username;
        //            USER.password = usuario.password;
        //            USER.identificacion = usuario.identificacion;
        //            USER.id_rol_usuario = usuario.idRol;
        //            USER.id_estado_usuario = usuario.idEstado;
        //            USER.id_tipo_Identificacion_usuario = usuario.idTipoIdentificacion;

        //            conexion.USUARIO.Add(USER);
        //            conexion.SaveChanges();

        //            var idUsu = from u in conexion.USUARIO
        //                        where u.identificacion == usuario.identificacion
        //                        select new Usuario
        //                        {
        //                            id = u.id_usuario
        //                        };

        //            Usuario user = idUsu.First();
        //            TELEFONO_USUARIO Telefono = new TELEFONO_USUARIO();
        //            Telefono.id_usuario_telefono = user.id;
        //            Telefono.numero_telefono = usuario.TelefonoCelular;
        //            conexion.TELEFONO_USUARIO.Add(Telefono);
        //            conexion.SaveChanges();

        //            if (usuario.TelefonoFijo != "")
        //            {
        //                TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
        //                Telefono2.id_usuario_telefono = user.id;
        //                Telefono2.numero_telefono = usuario.TelefonoFijo;
        //                conexion.TELEFONO_USUARIO.Add(Telefono2);
        //                conexion.SaveChanges();
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            resultado = e.Message;
        //        }
        //        resultado = "Empleado registrado correctamente";
        //        tipoResultado = "success";
        //    }
        //    else
        //    {
        //        resultado = "Ya existe un empleado registrado con el nombre de usuario, email o identificación ingresado";
        //        tipoResultado = "danger";
        //    }
        //}

        ///// <summary>
        ///// Modifica un empleado en específico y lo actualiza en base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        //public void ModificarEmpleado(Usuario usuario, out string res, out string tipoRes)
        //{

        //    try
        //    {
        //        var queryUSUARIO = from USU in conexion.USUARIO
        //                           where USU.identificacion == usuario.identificacion
        //                           select USU;
        //        foreach (var USUARIO in queryUSUARIO)
        //        {
        //            USUARIO.apellidos = usuario.apellidos;
        //            USUARIO.nombres = usuario.nombres;
        //            USUARIO.direccion = usuario.direccion;
        //            USUARIO.correo = usuario.email;
        //            USUARIO.sexo = usuario.sexo;
        //            USUARIO.password = usuario.password;
        //            USUARIO.id_rol_usuario = usuario.idRol;

        //        }
        //        conexion.SaveChanges();

        //        var idUsu = from u in conexion.USUARIO
        //                    where u.identificacion == usuario.identificacion
        //                    select new Usuario
        //                    {
        //                        id = u.id_usuario
        //                    };

        //        Usuario user = idUsu.First();
        //        var queryTelefono = from tel in conexion.TELEFONO_USUARIO
        //                            join usu in conexion.USUARIO
        //                            on tel.id_usuario_telefono equals usu.id_usuario
        //                            where usu.identificacion == usuario.identificacion
        //                            select tel;
        //        int i = 0;
        //        foreach (var tele in queryTelefono)
        //        {
        //            tele.id_usuario_telefono = user.id;
        //            if (i == 0)
        //                tele.numero_telefono = usuario.TelefonoCelular;
        //            else
        //            {
        //                tele.numero_telefono = usuario.TelefonoFijo;
        //            }
        //            i++;
        //        }

        //        conexion.SaveChanges();

        //        if (usuario.TelefonoFijo != "")
        //        {
        //            TELEFONO_USUARIO Telefono2 = new TELEFONO_USUARIO();
        //            Telefono2.id_usuario_telefono = user.id;
        //            Telefono2.numero_telefono = usuario.TelefonoFijo;
        //            conexion.TELEFONO_USUARIO.Add(Telefono2);
        //            conexion.SaveChanges();
        //        }
        //        res = "Empleado Modificado correctamente";
        //        tipoRes = "success";
        //    }
        //    catch (Exception e)
        //    {
        //        res = e.Message;
        //        tipoRes = "danger";
        //    }

        //}

        ///// <summary>
        ///// modifica el estado del Empleado solicitado en base de datos
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        //public void CambiarEstadoEmpleado(Usuario usuario, out string res, out string tipoRes)
        //{

        //    try
        //    {
        //        var queryUSUARIO = from USU in conexion.USUARIO
        //                           where USU.identificacion == usuario.identificacion
        //                           select USU;
        //        foreach (var USUARIO in queryUSUARIO)
        //        {
        //            USUARIO.id_estado_usuario = usuario.idEstado;
        //        }
        //        if (queryUSUARIO.Count() == 0)
        //        {
        //            res = "La Operación no Produjo ningun resultado";
        //            tipoRes = "danger";
        //        }
        //        else
        //        {
        //            res = "Estado del Empleado actualizado correctamente";
        //            tipoRes = "success";
        //        }
        //        conexion.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        res = e.Message;
        //        tipoRes = "danger";
        //    }


        //}
        //#endregion
    }
}