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
        public object CrearFacturaSinRegistros(string identifEmpleado, ref string resultado, ref string tipoResultado)
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
        public object ObtenerIdUltimaFacturaGenerada(ref string resultado, ref string tipoResultado)
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



        /// <summary>
        /// crea el detalle factura producto en la BD
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarDetalleFacturaProducto(int idProducto, int cantidad, int idFactura, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.AgregarDetalleFacturaProducto(idProducto, cantidad, idFactura);
                resultado = "";
                tipoResultado = "success";

            }
            catch
            {
                resultado = "No se ha podido agregar el detalle factura del producto";
                tipoResultado = "danger";
            }

        }

        /// <summary>
        /// crea el detalle factura solicitud en la BD
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarDetalleFacturaSolicitud(int idSolicitud, int cantidad, int idFactura, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.AgregarDetalleFacturaSolicitud(idSolicitud, cantidad, idFactura);
                resultado = "";
                tipoResultado = "success";

            }
            catch
            {
                resultado = "No se ha podido agregar el detalle factura solicitud";
                tipoResultado = "danger";
            }

        }


        /// <summary>
        /// Actualiza la factura vacia con los nuevos datos de facturacion creada
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void ActualizarFacturaVacia(string identifCliente, string identifEmpleado, int estado, int idFactura, decimal valorPagado, decimal total,
                                            DateTime fecha, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.ActualizarFacturaVacia(identifCliente, identifEmpleado, estado, idFactura, valorPagado, total, fecha);
                tipoResultado = "success";
            }
            catch
            {
                resultado = "No se ha podido actualizar la factura.  Intente más tarde";
                tipoResultado = "danger";
            }

        }



        /// <summary>
        /// consulta la cantidad actual de un producto en específico
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarCantidadProductoXid(int idProducto, ref string resultado, ref string tipoResultado)
        {

            object cantidad = null;
            try
            {
                cantidad = conexion.conexiones.ConsultarCantidadProductoXid(idProducto).ToList();
                tipoResultado = "success";
                return cantidad;
            }
            catch
            {
                resultado = "No se ha podido consultar la cantidad del producto.  Intente más tarde";
                tipoResultado = "danger";
            }

            return cantidad;
        }



        public void ActualizarInventarioXVenta(int idProducto, int cantidadVendida, DateTime fecha, string identifEmpleado, 
                                               ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.ActualizarInventarioXVenta(idProducto,cantidadVendida,fecha,identifEmpleado);
                tipoResultado = "success";
            }
            catch
            {
                resultado = "No se ha podido actualizar el inventario.  Intente más tarde";
                tipoResultado = "danger";
            }

        }

    }
}