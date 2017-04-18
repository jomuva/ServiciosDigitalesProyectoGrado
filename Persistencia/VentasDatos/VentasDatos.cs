using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.VentasDatos
{
    public class VentasDatos
    {
        private conexion conexion = new conexion();

        public VentasDatos()
        {

        }

        /// <summary>
        /// Crea la factura inicial sin registros para empezar con el proceso de venta
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object CrearFacturaSinRegistros(string identifEmpleado,ref string resultado, ref string tipoResultado)
        {

            object facturaInicial = null;
            try
            {
                facturaInicial = conexion.conexiones.CrearFacturaSinRegistros(identifEmpleado).ToList();

                resultado = "Iniciando Creación de Factura";
                tipoResultado = "success";
                return facturaInicial;
            }
            catch
            {
                resultado = "No se ha podido crear la factura inicial.  Intente más tarde";
                tipoResultado = "danger";
            }

            return facturaInicial;
        }


        /// <summary>
        /// TRAE EL ID(CONSECUTIVO) DE LA ULTIMA FACTURA CREADA
        /// </summary>
        /// <param name="identifEmpleado"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ObtenerIdUltimaFacturaGenerada( ref string resultado, ref string tipoResultado)
        {

            object idUltimaFactura = null;
            try
            {
                idUltimaFactura = conexion.conexiones.ObtenerIdUltimaFacturaGenerada().ToList();

               return idUltimaFactura;
            }
            catch
            {
                resultado = "No se ha podido traer el número de la última fáctura creada.  Intente más tarde";
                tipoResultado = "danger";
            }

            return idUltimaFactura;
        }



    }
}