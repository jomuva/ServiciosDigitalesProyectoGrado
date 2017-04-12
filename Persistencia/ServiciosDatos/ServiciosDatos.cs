using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.ServiciosDatos
{
    public class ServiciosDatos
    {
        private conexion conexion = new conexion();

        public ServiciosDatos()
        {

        }


        /// <summary>
        /// Agrega el servicio a la BD
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarServicio(string descripcion, out string resultado, out string tipoResultado)
        {
            try
            {
                conexion.conexiones.AgregarServicio(descripcion);
                conexion.conexiones.SaveChanges();

                resultado = "Se ha agregado el servicio exitosamente";
                tipoResultado = "success";

            }catch(Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }
            
        }

        /// <summary>
        /// Consulta la totalidad de servicios que hay en BD
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarServicios(ref string resultado, ref string tipoResultado)
        {
            object servicios=null;
            try
            {
                 servicios = conexion.conexiones.ConsultarServicios().ToList();

                resultado = "Consulta Exitosa";
                tipoResultado = "info";
                return servicios;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return servicios;
        }

        /// <summary>
        /// Consulta un servicio segun id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarServicio(int id,ref string resultado, ref string tipoResultado)
        {
            object servicios = null;
            try
            {
                servicios = conexion.conexiones.ConsultarServicio(id).ToList();

                resultado = "Consulta Exitosa";
                tipoResultado = "info";
                return servicios;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return servicios;
        }

        /// <summary>
        /// Modifica el producto segun su ID
        /// </summary>
        /// <param name="idProd"></param>
        /// <param name="nombre"></param>
        /// <param name="precioCosto"></param>
        /// <param name="precioVenta"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void ModificarServicio(int idServ,string descripcion, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.ActualizarServicio(idServ, descripcion);
                conexion.conexiones.SaveChanges();
                resultado = "Servicio Modificado correctamente";
                tipoResultado = "success";
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }

        }

    }
}