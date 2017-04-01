using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using Persistencia.UsuarioDatos;
using Newtonsoft.Json;

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
            List<TipoIdentificacion> Tipos = new List<TipoIdentificacion>();
           var tipos = usuarioDatos.ConsultarTiposIdentificacion();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new TipoIdentificacion
                {
                    id = data.id,
                    Descripcion = data.Descripcion,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta los tipos de estado que el usuario puede tener
        /// </summary>
        /// <returns></returns>
        public List<EstadosUsuario> ConsultarEstadosUsuario()
        {

            List<EstadosUsuario> Estados = new List<EstadosUsuario>();
            var tipos = usuarioDatos.ConsultarEstadosUsuario();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Estados.Add(new EstadosUsuario
                {
                    id = data.id,
                    Descripcion = data.Descripcion,
                });
            }

            return Estados;

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
            object oUsers;
            object otelefonos=null;
            string dynObj,dynObj2;
            dynamic dyn,dyn2;
            List<Usuario> ListaUsuarios = new List<Usuario>();
            List<TelefonoUsuario> telefonos = new List<TelefonoUsuario>();

            if (ident == "" || ident == null)
            {
                oUsers = usuarioDatos.ConsultarClientes();
                dynObj = JsonConvert.SerializeObject(oUsers);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    ListaUsuarios.Add(new Usuario
                    {
                        nombres = item.nombres,
                        apellidos = item.apellidos,
                        identificacion = item.identificacion,
                        username = item.username,
                        direccion = item.direccion,
                        email = item.email,
                        sexo = item.sexo,
                        estado = item.estado
                    });
                }

            }
            else if (ident != "")
            {
                oUsers = usuarioDatos.ConsultarCliente(ident, ref otelefonos, ref resultado, ref tipoResultado);
                dynObj = JsonConvert.SerializeObject(oUsers);
                dyn = JsonConvert.DeserializeObject(dynObj);

                dynObj2 = JsonConvert.SerializeObject(otelefonos);
                dyn2 = JsonConvert.DeserializeObject(dynObj2);

                foreach (var item in dyn)
                {
                    ListaUsuarios.Add(new Usuario
                    {
                        nombres = item.nombres,
                        apellidos = item.apellidos,
                        identificacion = item.identificacion,
                        username = item.username,
                        direccion = item.direccion,
                        email = item.email,
                        sexo = item.sexo,
                        estado = item.estado
                    });
                }

                foreach (var item in dyn2)
                {
                    telefonos.Add(new TelefonoUsuario
                    {
                        numero_telefono = item.numero_telefono,
                        id_usuario_telefono = item.id_usuario_telefono
                    });
                }

                ListaUsuarios[0].TelefonoCelular = telefonos[0].numero_telefono;
                ListaUsuarios[0].TelefonoFijo = telefonos.Count == 1 ? "" : telefonos[1].numero_telefono;

            }
            else
                oUsers = null;

            return ListaUsuarios;
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
            usuarioDatos.AdicionarCliente( 
                                            cliente.TelefonoFijo, cliente.TelefonoCelular, cliente.username,
                                            cliente.email, cliente.identificacion, cliente.nombres,
                                            cliente.apellidos, cliente.direccion,
                                            cliente.sexo, cliente.password,
                                            cliente.idRol, cliente.idEstado, cliente.idTipoIdentificacion,
                                            out resultado, out tipoResultado
                                          );
        }

        /// <summary>
        /// recoge la informacion enviada por el controlador para así complementarla y enviarla a la clase UsuarioDatos y asi enviarla a BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarCliente(Usuario cliente, out string res, out string tipoRes)
        {
            usuarioDatos.ModificarCliente
                                        (   
                                            cliente.TelefonoFijo, cliente.TelefonoCelular, cliente.username,
                                            cliente.email, cliente.identificacion, cliente.nombres, cliente.apellidos,
                                            cliente.direccion, cliente.sexo, cliente.password, cliente.idTipoIdentificacion,
                                            out res, out tipoRes
                                        );
        }


        ///// <summary>
        ///// recoge la informacion necesario desde el controlador para asi enviarlo a la clase UsuarioDatos y actualizarla en BD
        ///// </summary>
        ///// <param name="cliente"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        public void CambiarEstadoCliente(Usuario cliente, out string res, out string tipoRes)
        {
            usuarioDatos.CambiarEstadoCliente(cliente.idEstado, cliente.identificacion, out res, out tipoRes);
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
            object oUsers;
            object otelefonos = null;
            string dynObj, dynObj2;
            dynamic dyn, dyn2;
            List<Usuario> ListaUsuarios = new List<Usuario>();
            List<TelefonoUsuario> telefonos = new List<TelefonoUsuario>();


            if (ident == "" || ident == null)
            {
                oUsers = usuarioDatos.ConsultarEmpleados();
                dynObj = JsonConvert.SerializeObject(oUsers);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    ListaUsuarios.Add(new Usuario
                    {
                        nombres = item.nombres,
                        apellidos = item.apellidos,
                        identificacion = item.identificacion,
                        username = item.username,
                        direccion = item.direccion,
                        email = item.email,
                        sexo = item.sexo,
                        estado = item.estado,
                        Rol = item.Rol

                    });

                }


            }
            else if (ident != "")
            {
                oUsers = usuarioDatos.ConsultarEmpleado(ident, ref otelefonos, ref resultado, ref tipoResultado);

                dynObj = JsonConvert.SerializeObject(oUsers);
                dyn = JsonConvert.DeserializeObject(dynObj);

                dynObj2 = JsonConvert.SerializeObject(otelefonos);
                dyn2 = JsonConvert.DeserializeObject(dynObj2);

                foreach (var item in dyn)
                {
                    ListaUsuarios.Add(new Usuario
                    {
                        nombres = item.nombres,
                        apellidos = item.apellidos,
                        identificacion = item.identificacion,
                        username = item.username,
                        direccion = item.direccion,
                        email = item.email,
                        sexo = item.sexo,
                        estado = item.estado,
                        Rol = item.Rol
                    });
                }

                foreach (var item in dyn2)
                {
                    telefonos.Add(new TelefonoUsuario
                    {
                        numero_telefono = item.numero_telefono,
                        id_usuario_telefono = item.id_usuario_telefono
                    });
                }

                ListaUsuarios[0].TelefonoCelular = telefonos[0].numero_telefono;
                ListaUsuarios[0].TelefonoFijo = telefonos.Count == 1 ? "" : telefonos[1].numero_telefono;

            }
            else
                oUsers = null;

            return ListaUsuarios;
        }


        /// <summary>
        /// envía la información recogida desde el controlador a la clase que conecta con base de datos
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AdicionarEmpleado(Usuario cliente, out string resultado, out string tipoResultado)
        {
            cliente.idEstado = 1;
            usuarioDatos.AdicionarEmpleado
                                    (
                                         cliente.TelefonoFijo, cliente.TelefonoCelular, cliente.username, cliente.email,
                                         cliente.identificacion, cliente.nombres, cliente.apellidos, cliente.direccion,
                                         cliente.sexo, cliente.password, cliente.idRol, cliente.idEstado, cliente.idTipoIdentificacion,
                                        out resultado, out tipoResultado
                                    );

        }

        /// <summary>
        /// recoge la informacion enviada por el controlador para así complementarla y enviarla a la clase UsuarioDatos y asi enviarla a BD
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ModificarEmpleado(Usuario cliente, out string res, out string tipoRes)
        {
            cliente.idEstado = 1;
            usuarioDatos.ModificarEmpleado
                                           (
                                                cliente.TelefonoFijo, cliente.TelefonoCelular, cliente.username,
                                                cliente.email, cliente.identificacion, cliente.nombres, cliente.apellidos,
                                                cliente.direccion, cliente.sexo, cliente.password, cliente.idTipoIdentificacion, 
                                                cliente.idRol, out res, out tipoRes
                                           );
        }


        /// <summary>
        /// recoge la informacion necesario desde el controlador para asi enviarlo a la clase UsuarioDatos y actualizarla en BD
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void CambiarEstadoEmpleado(Usuario empleado, out string res, out string tipoRes)
        {
            usuarioDatos.CambiarEstadoEmpleado(empleado.identificacion, empleado.idEstado, out res, out tipoRes);
        }

        /// <summary>
        /// Consulta los roles que un empleado puede tener
        /// </summary>
        /// <returns></returns>
        public List<Rol> ConsultarRolesEmpleado()
        {
            List<Rol> Roles = new List<Rol>();
            var roles = usuarioDatos.ConsultarRolEmpleado();

            string dynObj = JsonConvert.SerializeObject(roles);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Roles.Add(new Rol
                {
                    id = data.id,
                    Descripcion = data.Descripcion,
                });
            }

            return Roles;
        }
        #endregion
    }


}