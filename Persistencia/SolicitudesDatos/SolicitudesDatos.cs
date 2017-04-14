using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.SolicitudesDatos
{
    public class SolicitudesDatos
    {
        private conexion conexion = new conexion();

        public SolicitudesDatos()
        {

        }

        /// <summary>
        /// Agrega un elemento a la base de datos
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="placa"></param>
        /// <param name="modelo"></param>
        /// <param name="marca"></param>
        /// <param name="ram"></param>
        /// <param name="rom"></param>
        /// <param name="serialBateria"></param>
        /// <param name="SO"></param>
        /// <param name="idTipoElemento"></param>
        /// <param name="idCategoriaElemento"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarElemento(string serial, string placa, string modelo, string marca,
            string ram, string rom, string serialBateria, string SO, int idTipoElemento, int idCategoriaElemento,
            ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.AgregarElemento(idCategoriaElemento,idTipoElemento,serial,placa,modelo,marca,ram,rom,serialBateria,SO);
                conexion.conexiones.SaveChanges();

                resultado = "Se ha insertado el elemento exitosamente";
                tipoResultado = "success";

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

        }

        public object ConsultarElementos()
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarElementos().ToList();
            }
            catch (Exception e)
            {
            }
            return consulta;
        }
        /// <summary>
        /// Consultar los Tipos de prioridad de la solicitud
        /// </summary>
        /// <returns></returns>
        public object ConsultarTiposPrioridad()
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarTiposPrioridad().ToList();
            }
            catch (Exception e)
            {
            }
            return consulta;
        }

        /// <summary>
        /// Consultar los tipos de elemento de los elementos
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarTiposElemento()
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarTiposElemento().ToList();
               
            }
            catch (Exception e)
            {
               
            }
            return consulta;
        }

        /// <summary>
        /// Consulta las categorias posibles de un elemento
        /// </summary>
        /// <returns></returns>
        public object ConsultarCategoriasElemento()
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarCategorias_Elemento().ToList();

            }
            catch (Exception e)
            {

            }
            return consulta;
        }

        /// <summary>
        /// Consulta los estados posibles de la solicitud y los trae en una lista
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarEstadosSolicitud()
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarEstadosSolicitud().ToList();
            }
            catch (Exception e)
            {
            }
            return consulta;
        }


        /// <summary>
        /// Consulta el estado de la solicitud segun el id del cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarEstadoSolicitud_X_id(int idSolicitud,ref string resultado, ref string tipoResultado)
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarEstado_Solicitud(idSolicitud).ToList();
                resultado = "Consulta Exitosa";
                tipoResultado = "info";
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "error";
            }
            return consulta;
        }

        /// <summary>
        /// modifica el estado de la solicitud segun id de solicitud
        /// </summary>
        /// <param name="id"></param>
        /// <param name=""></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public object CambiarEstadoSolicitud(int idSolicitud,int idEstadoAnterior,int idEstadoNuevo,string identif,ref string resultado, ref string tipoResultado)
        {
            object res=null;
            try
            {
                 res = conexion.conexiones.CambiarEstadoSolicitud(idSolicitud,idEstadoAnterior,idEstadoNuevo,identif).ToList();
                conexion.conexiones.SaveChanges();

                resultado = "Se ha Cambiado el estado de la solicitud "+ idSolicitud + " satisfactoriamente!.  Consulte el Histórico";
                tipoResultado = "success";

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }
            return res;
        }

        /// <summary>
        /// Consulta todas las solicitudes en BD
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarSolicitudes(ref string resultado, ref string tipoResultado)
        {

            object solicitudes = null;
            try
            {
               solicitudes =  conexion.conexiones.ConsultarSolicitudes().ToList();
                resultado = "Consulta Exitosa";
                tipoResultado = "info";

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "error";
            }

            return solicitudes;
        }

        public object ConsultarSolicitudesXEmpleado(string identif,ref string resultado, ref string tipoResultado)
        {

            object solicitudes = null;
            try
            {
                solicitudes = conexion.conexiones.ConsultarSolicitudesXEmpleado(identif).ToList();
                resultado = "Consulta Exitosa";
                tipoResultado = "info";

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "error";
            }

            return solicitudes;
        }


        public object ConsultaNombresEmpleadosXSolicitud()
        {
            object solicitudes = null;
            try
            {
                solicitudes = conexion.conexiones.ConsultaNombresEmpleadosXSolicitud().ToList();
            }
            catch (Exception ex)
            {
          
            }

            return solicitudes;
        }




        /// <summary>
        /// Agrega una solicitud a la BD
        /// </summary>
        /// <param name="id_prioridad"></param>
        /// <param name="id_estado"></param>
        /// <param name="id_cliente"></param>
        /// <param name="id_servicio"></param>
        /// <param name="id_elemento"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void GenerarSolicitud(int id_prioridad,int id_estado,string identifEmpleado, int id_cliente,int id_servicio,int id_elemento,string descripcion, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.GenerarSolicitud(id_prioridad, id_estado, identifEmpleado,id_cliente, id_servicio, id_elemento,descripcion);
                conexion.conexiones.SaveChanges();

                resultado = "Se ha generado la solicitud exitosamente";
                tipoResultado = "success";

            }catch(Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }
            
        }

        /// <summary>
        /// Escala la solicitud segun el numero de documento del empleado a escalar
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void EscalarSolicitud(int idSolicitud, string identifEmpleado, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.EscalarSolicitud(idSolicitud,identifEmpleado);
                conexion.conexiones.SaveChanges();

                resultado = "Se ha Escalado la solicitud exitosamente";
                tipoResultado = "success";

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

        }

        /// <summary>
        /// DEvuelve el historico de una solicitud segun su id
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarHistoricoSolicitudX_id(int idSolicitud , ref string resultado, ref string tipoResultado )
        {
            object solicitudes = null;
            try
            {
                solicitudes = conexion.conexiones.ConsultarHistoricoSolicitudX_id(idSolicitud).ToList();
                resultado = "Se ha Escalado la solicitud exitosamente";
                tipoResultado = "success";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return solicitudes;
        }


    }
}