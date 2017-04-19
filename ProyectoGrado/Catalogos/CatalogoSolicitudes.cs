using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using Persistencia.SolicitudesDatos;
using Persistencia.UsuarioDatos;
using Newtonsoft.Json;
using Helper;

namespace ServiciosDigitalesProy.Catalogos
{
    public class CatalogoSolicitudes
    {
        private static CatalogoSolicitudes catalogoSolicitudes = null;
        private static SolicitudesDatos solicitudesDatos = null;
        private static UsuarioDatos usuariosDatos = null;

        public CatalogoSolicitudes()
        {
            solicitudesDatos = new SolicitudesDatos();

        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoSolicitudes GetInstance()
        {
            if (catalogoSolicitudes == null)
                catalogoSolicitudes = new CatalogoSolicitudes();
            return catalogoSolicitudes;
        }

        #region Elemento

        /// <summary>
        /// Consulta los tipos de elemento y los convierte a modelo 
        /// </summary>
        /// <returns></returns>
        public List<TipoElemento> ConsultarTiposElemento()
        {
            List<TipoElemento> Tipos = new List<TipoElemento>();
            var tipos = solicitudesDatos.ConsultarTiposElemento();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new TipoElemento
                {
                    id = data.id_tipo_elemento,
                    Descripcion = data.descripcion_elemento,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta los tipos de prioridad existentes
        /// </summary>
        /// <returns></returns>
        public List<PrioridadSolicitud> ConsultarTiposPrioridad()
        {
            List<PrioridadSolicitud> Tipos = new List<PrioridadSolicitud>();
            var tipos = solicitudesDatos.ConsultarTiposPrioridad();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new PrioridadSolicitud
                {
                    id = data.id_prioridad,
                    Descripcion = data.descripcion_prioridad,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta todos los tips de estado de solicitud para combobox
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<EstadoSolicitud> ConsultarEstadosSolicitud()
        {
            List<EstadoSolicitud> Tipos = new List<EstadoSolicitud>();
            var tipos = solicitudesDatos.ConsultarEstadosSolicitud();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new EstadoSolicitud
                {
                    id = data.id_estado_solicitud,
                    Descripcion = data.descripcion,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta las categorias de elemento y las convierte a modelo
        /// </summary>
        /// <returns></returns>
        public List<CategoriaElemento> ConsultarCategoriasElemento()
        {
            List<CategoriaElemento> Tipos = new List<CategoriaElemento>();
            var tipos = solicitudesDatos.ConsultarCategoriasElemento();

            string dynObj = JsonConvert.SerializeObject(tipos);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Tipos.Add(new CategoriaElemento
                {
                    id = data.id_categoria_elemento,
                    Descripcion = data.descripcion_categoria_elemento,
                });
            }

            return Tipos;
        }

        /// <summary>
        /// Consulta Estado Solicitud segun id solicitud 
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public Solicitud ConsultaEstadoSolicitud_X_id(int idSolicitud, ref string resultado, ref string tipoResultado)
        {
            Solicitud solicitud = new Solicitud();
            EstadoSolicitud estado = new EstadoSolicitud();
            var Estado = solicitudesDatos.ConsultarEstadoSolicitud_X_id(idSolicitud, ref resultado, ref tipoResultado);

            if (tipoResultado != "danger")
            {
                string dynObj2 = JsonConvert.SerializeObject(Estado);
                dynamic dyn2 = JsonConvert.DeserializeObject(dynObj2);

                foreach (var item in dyn2)
                {
                    estado.id = item.id_estado_solicitud;
                    estado.Descripcion = item.descripcion;
                }
                //solicitud.estadoSolicitud.id = dyn2.id_estado_solicitud;
                //solicitud.estadoSolicitud.Descripcion = dyn2.descripcion;
                resultado = "";
                tipoResultado = "";
                solicitud.estadoSolicitud = estado;
            }
            return solicitud;
        }

        /// <summary>
        /// Envia el nuevo estado de solicitud con el empleado logueado para ingresarlo a la base de datos y su histórico
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="idEstadoAnterior"></param>
        /// <param name="idEstadoNuevo"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void CambiarEstadoSolicitud(int idSolicitud, int idEstadoAnterior, int idEstadoNuevo, ref string resultado, ref string tipoResultado)
        {
            int identifEmpleado = SessionHelper.GetUser();
            int respInt;
            string respuesta = "";
            object resul;
            resul = solicitudesDatos.CambiarEstadoSolicitud(idSolicitud, idEstadoAnterior, idEstadoNuevo, identifEmpleado.ToString(), ref resultado, ref tipoResultado);

            string dynObj2 = JsonConvert.SerializeObject(resul);
            dynamic dyn2 = JsonConvert.DeserializeObject(dynObj2);

            foreach (var item in dyn2)
            {
                respuesta = item;

            }
            respInt = respuesta == "" ? respInt = 0 : Convert.ToInt32(respuesta);
            if (respInt == 0)
            {
                resultado = "El cambio de dicho estado no se puede realizar";
                tipoResultado = "danger";
            }
        }
        /// <summary>
        /// Envia informacion a la capa de persistencia para adicionar un elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarElemento(Elemento elemento, ref string resultado, ref string tipoResultado)
        {
            solicitudesDatos.AgregarElemento(
                                                elemento.serial, elemento.placa, elemento.modelo, elemento.marca, elemento.ram,
                                                elemento.rom, elemento.serialBateria, elemento.SO,
                                                elemento.tipoElemento.id, elemento.categoriaElemento.id,
                                                ref resultado, ref tipoResultado
                                                );
        }


        public List<Elemento> ConsultarElementos(ref string resultado, ref string tipoResultado)
        {
            List<Elemento> elementos = new List<Elemento>();
            var oElementos = solicitudesDatos.ConsultarElementos();

            string dynObj2 = JsonConvert.SerializeObject(oElementos);
            dynamic dyn2 = JsonConvert.DeserializeObject(dynObj2);

            foreach (var item in dyn2)
            {
                elementos.Add(new Elemento
                {
                    id_elemento = item.id_elemento,
                    serial = item.serial,
                    placa = item.placa,
                    modelo = item.modelo,
                    marca = item.marca,
                    ram = item.ram,
                    rom = item.rom,
                    serialBateria = item.serial_bateria,
                    SO = item.sistema_operativo,
                    tipoElemento = new TipoElemento((int)item.id_tipo_elemento,(string)item.descripcion_elemento),
                    categoriaElemento = new CategoriaElemento((int)item.id_categoria_elemento,(string)item.descripcion_categoria_elemento)
                });
            }
            resultado = "";
            tipoResultado = "";
            return elementos;
        }

        #endregion
        /// <summary>
        /// Consulta el total de solicitudes y en este metodo los convierte a Objeto Solicitud
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Solicitud> ConsultarSolicitudes(ref string resultado, ref string tipoResultado)
        {
            object oSolicitudes, oNombres = null;
            string dynObj, dynobj2, dynObj3;
            dynamic dyn, dyn2, dyn3;
            int Rol = 0;
            List<Solicitud> ListaSolicitudes = new List<Solicitud>();
            string identif = (SessionHelper.GetUser()).ToString();

            usuariosDatos = new UsuarioDatos();
            var oRol = usuariosDatos.ConsultarRolUsuario(identif);
            dynobj2 = JsonConvert.SerializeObject(oRol);
            dyn2 = JsonConvert.DeserializeObject(dynobj2);
            foreach (var item in dyn2) { Rol = item; }

            if (Rol == 2)
            {
                oSolicitudes = solicitudesDatos.ConsultarSolicitudes(ref resultado, ref tipoResultado);
                oNombres = solicitudesDatos.ConsultaNombresEmpleadosXSolicitud();

            }
            else
            {
                oSolicitudes = solicitudesDatos.ConsultarSolicitudesXEmpleado(identif, ref resultado, ref tipoResultado);
            }
            dynObj = JsonConvert.SerializeObject(oSolicitudes);
            dyn = JsonConvert.DeserializeObject(dynObj);
            foreach (var item in dyn)
            {
                ListaSolicitudes.Add(new Solicitud
                {
                    idEmpleado = item.id_escalado_solicitud,
                    estadoSolicitud = new EstadoSolicitud((string)item.Expr1),
                    id_solicitud = item.id_solicitud,
                    prioridadSolicitud = new PrioridadSolicitud((string)item.descripcion_prioridad),
                    cliente = new Usuario((string)item.identificacion, (string)item.apellidos, (string)item.nombres),
                    fecha = item.fecha_solicitud,
                    elemento = new Elemento((string)item.descripcion_categoria_elemento, (string)item.descripcion_elemento, (string)item.serial, (string)item.placa, (string)item.modelo, (string)item.marca, (string)item.ram, (string)item.rom, (string)item.serial_bateria, (string)item.sistema_operativo),
                    descripcion = item.descripcion,
                    servicio = new Servicio((string)item.descripcion_servicio,(double)item.precio)
                });
            }
            if (Rol == 2)
            {
                List<Solicitud> solicitudes2 = new List<Solicitud>();
                dynObj3 = JsonConvert.SerializeObject(oNombres);
                dyn3 = JsonConvert.DeserializeObject(dynObj3);
                int tamañoNombres;
                foreach (var nom in dyn3)
                {
                    solicitudes2.Add(new Solicitud
                    {
                        Empleado = nom
                    });
                }
                tamañoNombres = solicitudes2.Count;
                for (int i = 0; i < tamañoNombres; i++)
                {
                    ListaSolicitudes[i].Empleado = solicitudes2[i].Empleado;
                }
            }

            return ListaSolicitudes;
        }




        /// <summary>
        /// Agrega una solicitud y verificar si la solicitud tiene un elemento para agregar o no
        /// </summary>
        /// <returns></returns>
        public void GenerarSolicitud(Solicitud solicitud, ref string resultado, ref string tipoResultado)
        {

            solicitudesDatos.GenerarSolicitud(
                                                solicitud.prioridadSolicitud.id, solicitud.estadoSolicitud.id,
                                                SessionHelper.GetUser().ToString(),
                                                solicitud.cliente.id, solicitud.servicio.id_servicio, solicitud.elemento.id_elemento,
                                                solicitud.descripcion, ref resultado, ref tipoResultado);
        }

        /// <summary>
        /// Escalar la solicitud y se envia a capa de persistencia
        /// </summary>
        /// <param name="solicitud"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void EscalarSolicitud(Solicitud solicitud, ref string resultado, ref string tipoResultado)
        {

            solicitudesDatos.EscalarSolicitud(solicitud.id_solicitud, solicitud.idEmpleado.ToString(), ref resultado, ref tipoResultado);
        }


        /// <summary>
        /// Consulta el historico de la solicitud segun el id de la solicitud
        /// </summary>
        /// <param name="idSolic"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<HistoricoSolicitud> ConsultarHistoricoSolicitudX_id(int idSolic, ref string resultado, ref string tipoResultado)
        {
            List<HistoricoSolicitud> historicosXid = new List<HistoricoSolicitud>();
            var oHistorico = solicitudesDatos.ConsultarHistoricoSolicitudX_id(idSolic, ref resultado, ref tipoResultado);


            string dynObj2 = JsonConvert.SerializeObject(oHistorico);
            dynamic dyn2 = JsonConvert.DeserializeObject(dynObj2);

            foreach (var item in dyn2)
            {
                historicosXid.Add(new HistoricoSolicitud
                {
                    fecha = item.fecha_historico,
                    descripcion = item.descripcion_historico,
                    empleado = new Usuario((string)item.apellidos, (string)item.nombres),
                    id_solicitud = item.id_solicitud
                });
            }

            return historicosXid;
        }


        public void AgregarAnotacionHistorico(int idSolici,string descripcion, ref string resultado, ref string tipoResultado)
        {

            solicitudesDatos.AgregarAnotacionHistorico(idSolici,SessionHelper.GetUser().ToString(),
                descripcion,ref resultado,ref tipoResultado);
        }


     

    }


}