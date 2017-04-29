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


        /// <summary>
        /// Actualiza el inventario de productos luego de una venta
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="cantidadVendida"></param>
        /// <param name="fecha"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
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


        /// <summary>
        /// CONSULTA LA FACTURA COMPLETA SEGUN SU ID PARA PRESENTARLA AL USUARIO
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarFacturaXid(int idFactura, ref string resultado, ref string tipoResultado)
        {
            object factura = null;

            try
            {
                factura = conexion.conexiones.ConsultarFacturaXid(idFactura).ToList();
                tipoResultado = "success";
            }
            catch 
            {

                resultado = "Error al consultar la factura.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return factura;
        }

        /// <summary>
        /// CONSULTA TODAS LAS FACTURAS EXISTENTES
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarFacturas(ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ConsultarFacturas().ToList();
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al consultar las facturas.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }


        public object ConsultarDetallesFacturaProductoXid(int idFactura, ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ConsultarDetallesFacturaProductoXid(idFactura).ToList();
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al consultar el detalle de producto.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }


        public object ConsultarDetallesFacturaSolicitudXid(int idFactura, ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ConsultarDetallesFacturaSolicitudXid(idFactura).ToList();
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al consultar el detalle de solicitud.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }


        /// <summary>
        /// Consulta el estado de la factura segun su id
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarEstadoFactura(int idFactura, ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ConsultarEstadoFactura(idFactura).ToList();
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al consultar el estado de la factura.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }

        public object ActualizarEstadoFactura(int idFactura,int idEstado, decimal nuevoPago,string identifEmpleado,ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ActualizarEstadoFactura(idFactura,idEstado,nuevoPago,identifEmpleado);
                resultado = "Actualización de factura realizada correctamente";
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al actualizar el estado de la factura.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }

        /// <summary>
        /// CONSULTA EL HISTORICO DE UNA FACTURA ESPECIFICA
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarHistoricoFacturaXid(int idFactura, ref string resultado, ref string tipoResultado)
        {
            object facturas = null;

            try
            {
                facturas = conexion.conexiones.ConsultarHistoricoFacturaX_id(idFactura).ToList();
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al consultar el histórico de la factura.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

            return facturas;
        }

        /// <summary>
        /// ANULA UNA FACTURA Y SE ANOTA EL MOTIVO
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="idEstado"></param>
        /// <param name="nuevoPago"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public void AnularFactura(int idFactura, string identifEmpleado,string Motivo, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.AnularFactura(idFactura, identifEmpleado,Motivo);
                resultado = "Anulación de factura realizada correctamente";
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al Anular la factura.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

        }

        public void ReintegrarProductoXAnulacionFactura(int idFactura, int idProducto,string identifEmpleado, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.ReintegrarProductoXAnulacionFactura(idFactura,idProducto, identifEmpleado);
                resultado = "Reintegracion de producto realizado correctamente";
                tipoResultado = "success";
            }
            catch
            {

                resultado = "Error al reintegrar producto al inventario.  Por favor intente más tarde";
                tipoResultado = "danger";
            }

        }


    }
}