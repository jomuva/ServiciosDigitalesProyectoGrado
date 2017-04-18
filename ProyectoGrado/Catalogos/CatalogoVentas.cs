using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.VentasDatos;
using Newtonsoft.Json;
using ServiciosDigitalesProy.Models;
using Helper;

namespace ProyectoGrado.Catalogos
{
    public class CatalogoVentas
    {
        private static CatalogoVentas catalogoVentas = null;
        private static VentasDatos ventasDatos = null;

        public CatalogoVentas()
        {
            ventasDatos = new VentasDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoVentas GetInstance()
        {
            if (catalogoVentas == null)
                catalogoVentas = new CatalogoVentas();
            return catalogoVentas;
        }


        /// <summary>
        /// Consulta el total de inventarios o un inventario de algun producto en especial
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public Factura CrearFacturaSinRegistros(ref string resultado, ref string tipoResultado)
        {
            object oFactura = null;
            string dynObj;
            dynamic dyn;

            oFactura = ventasDatos.CrearFacturaSinRegistros(SessionHelper.GetUser().ToString(), ref resultado, ref tipoResultado);
            Factura factura = new Factura();
            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFactura);
                dyn = JsonConvert.DeserializeObject(dynObj);
               
                foreach (var item in dyn)
                {
                    factura.id_factura = item.id_factura;
                    factura.fecha = item.fecha;

                }
            }
            return factura;
        }


        /// <summary>
        /// TRAE EL ID DE LA ULTIMA FACTURA CREADA
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public int ObtenerIdUltimaFacturaGenerada(ref string resultado, ref string tipoResultado)
        {
            object oFactura = null;
            string dynObj;
            dynamic dyn;

            oFactura = ventasDatos.ObtenerIdUltimaFacturaGenerada(ref resultado, ref tipoResultado);
            int id = 0;
            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFactura);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    id = Convert.ToInt32(item);

                }
            }
            return id;
        }

        /// <summary>
        /// Guarda la factura en BD y almacena en tablas de detalles, factura, actualiza el inventario y agrega en su 
        /// historico
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void GuardarFactura(Factura factura, ref string resultado, ref string tipoResultado)
        {
            Factura facturaVacia = CrearFacturaSinRegistros(ref resultado, ref tipoResultado);
            int idFactura = ObtenerIdUltimaFacturaGenerada(ref  resultado, ref tipoResultado);

            //Agrego los detalles de la factura PRODUCTO si los hay
            List<DetalleFacturaProducto> detallesProductos = factura.listaDetallesProducto;
            if (detallesProductos.Count != 0)
            {
                foreach (var item in detallesProductos)
                {
                    ventasDatos.AgregarDetalleFacturaProducto(item.producto.id_producto,item.cantidad,idFactura,ref resultado, ref tipoResultado);

                    ventasDatos.ActualizarInventarioXVenta(item.producto.id_producto,item.cantidad,facturaVacia.fecha, SessionHelper.GetUser().ToString(), ref resultado, ref tipoResultado);

                }

            }


            //Agrego los detalles de la factura SOLICITUDES si los hay
            List<DetalleFacturaSolicitud> detallesSolicitudes = factura.listaDetallesSolicitud;
            if (detallesSolicitudes.Count != 0)
            {
                foreach (var item in detallesSolicitudes)
                {
                    ventasDatos.AgregarDetalleFacturaSolicitud(item.solicitud.id_solicitud,1, idFactura, ref resultado, ref tipoResultado);
                }
            }

            //Actualizo la factura que estaba vacia

            ventasDatos.ActualizarFacturaVacia(factura.cliente.identificacion,SessionHelper.GetUser().ToString(),factura.estado.id,
                                                idFactura, Convert.ToDecimal(factura.valorPagado),Convert.ToDecimal(factura.total),
                                                facturaVacia.fecha, ref resultado, ref tipoResultado);

            //Actualizo el inventario segun la venta realizada

        }

    }
}