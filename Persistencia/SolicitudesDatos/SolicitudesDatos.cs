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


        /// <summary>
        /// Consultar los Tipos de prioridad de la solicitud
        /// </summary>
        /// <returns></returns>
        public object ConsultarTiposPrioridad(ref string resultado, ref string tipoResultado)
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarTiposPrioridad().ToList();
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
        /// Consulta los estados posibles de la solicitud y los trae en una lista
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarEstadosSolicitud(ref string resultado, ref string tipoResultado)
        {
            object consulta = null;
            try
            {
                consulta = conexion.conexiones.ConsultarEstadosSolicitud().ToList();
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
        public void GenerarSolicitud(int id_prioridad,int id_estado,int id_cliente, int id_servicio,int id_elemento,string descripcion, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.GenerarSolicitud(id_prioridad, id_estado, id_cliente, id_servicio, id_elemento,descripcion);
                conexion.conexiones.SaveChanges();

                resultado = "Se ha generado la solicitud exitosamente";
                tipoResultado = "success";

            }catch(Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }
            
        }


    }
}