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
            int idFactura = ObtenerIdUltimaFacturaGenerada(ref resultado, ref tipoResultado);

            //Agrego los detalles de la factura PRODUCTO si los hay
            List<DetalleFacturaProducto> detallesProductos = factura.listaDetallesProducto;
            if (detallesProductos.Count != 0)
            {
                foreach (var item in detallesProductos)
                {
                    ventasDatos.AgregarDetalleFacturaProducto(item.producto.id_producto, item.cantidad, idFactura, ref resultado, ref tipoResultado);

                    ventasDatos.ActualizarInventarioXVenta(item.producto.id_producto, item.cantidad, facturaVacia.fecha, SessionHelper.GetUser().ToString(), ref resultado, ref tipoResultado);

                }

            }


            //Agrego los detalles de la factura SOLICITUDES si los hay
            List<DetalleFacturaSolicitud> detallesSolicitudes = factura.listaDetallesSolicitud;
            if (detallesSolicitudes.Count != 0)
            {
                foreach (var item in detallesSolicitudes)
                {
                    ventasDatos.AgregarDetalleFacturaSolicitud(item.solicitud.id_solicitud, 1, idFactura, ref resultado, ref tipoResultado);
                }
            }

            //Actualizo la factura que estaba vacia

            ventasDatos.ActualizarFacturaVacia(factura.cliente.identificacion, SessionHelper.GetUser().ToString(), factura.estado.id,
                                                idFactura, Convert.ToDecimal(factura.valorPagado), Convert.ToDecimal(factura.total),
                                                facturaVacia.fecha, ref resultado, ref tipoResultado);

        }


        /// <summary>
        /// Consulta todas las facturas completas
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Factura> ConsultarFacturas(ref string resultado, ref string tipoResultado)
        {
            object oFacturas = null, oDetallesProducto = null, oDetallesSolicitudes = null;
            List<Factura> facturas = new List<Factura>();
            List<DetalleFacturaProducto> DetallesFacturaProductos = new List<DetalleFacturaProducto>();
            List<DetalleFacturaSolicitud> DetallesFacturaSolicitudes = new List<DetalleFacturaSolicitud>();
            DetalleFacturaProducto detalleProducto = new DetalleFacturaProducto();
            string dynObj, dynObj2;
            dynamic dyn, dyn2;
            int idFacturaDetalle = 0;
            int i = 1;
            oFacturas = ventasDatos.ConsultarFacturas(ref resultado, ref tipoResultado);

            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFacturas);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    facturas.Add(new Factura
                    {
                        id_factura = item.id_factura,
                        estado = new EstadoFactura((string)item.descripcion_estado_factura),
                        fecha = item.fecha,
                        valorPagado = item.saldo,
                        total = item.valor_total,
                        cliente = new Usuario((string)item.identificacion, (string)item.apellidos, (string)item.nombres)
                    });

                    //busco lista de detalles de producto segun id factura
                    oDetallesProducto = ventasDatos.ConsultarDetallesFacturaProductoXid(i, ref resultado, ref tipoResultado);
                    DetallesFacturaProductos = new List<DetalleFacturaProducto>();
                    dynObj2 = JsonConvert.SerializeObject(oDetallesProducto);
                    dyn2 = JsonConvert.DeserializeObject(dynObj2);
                    int ContDetallesProd = 0;
                    foreach (var item2 in dyn2)
                    {
                        DetallesFacturaProductos.Add(new DetalleFacturaProducto
                        {
                            
                            producto = new Producto((string)item2.nombre_producto,(string)item2.precio_venta),
                            cantidad = (int)item2.cantidad_venta,
                        });
                        double precio = Convert.ToDouble(DetallesFacturaProductos[ContDetallesProd].producto.precio);
                        DetallesFacturaProductos[ContDetallesProd].subtotal = DetallesFacturaProductos[ContDetallesProd].cantidad * precio;
                        DetallesFacturaProductos[ContDetallesProd].producto.precio_venta = precio;
                        ContDetallesProd++;
                    }
                    facturas[idFacturaDetalle].listaDetallesProducto = DetallesFacturaProductos;

                    oDetallesProducto = null;
                    dyn2 = null;
                    dynObj2 = null;
                    //busco lista de detalles de solicitudes segun id factura
                    oDetallesSolicitudes = ventasDatos.ConsultarDetallesFacturaSolicitudXid(i, ref resultado, ref tipoResultado);
                    DetallesFacturaSolicitudes = new List<DetalleFacturaSolicitud>();
                    dynObj2 = JsonConvert.SerializeObject(oDetallesSolicitudes);
                    dyn2 = JsonConvert.DeserializeObject(dynObj2);
                    int ContDetallesProd2 = 0;
                    foreach (var item2 in dyn2)
                    {
                        DetallesFacturaSolicitudes.Add(new DetalleFacturaSolicitud
                        {
                            solicitud = new Solicitud((new Servicio((string)item2.descripcion_servicio, (string)item2.precio))),
                        });
                        DetallesFacturaSolicitudes[ContDetallesProd2].solicitud.servicio.sPrecio = (string)item2.precio;
                        double precio = Convert.ToDouble(DetallesFacturaSolicitudes[ContDetallesProd2].solicitud.servicio.sPrecio);
                        DetallesFacturaSolicitudes[ContDetallesProd2].solicitud.servicio.precio = precio;
                        ContDetallesProd2++;
                    }
                   
                    facturas[idFacturaDetalle].listaDetallesSolicitud = DetallesFacturaSolicitudes;
                    i++;
                    idFacturaDetalle++;
                    oDetallesSolicitudes = null;
                }
            }
            return facturas;
        }


        public Factura ConsultarEstadoFactura(int idFactura,ref string resultado, ref string tipoResultado)
        {
            object oFactura = null;
            string dynObj;
            dynamic dyn;
            Factura factura = new Factura();

            oFactura = ventasDatos.ConsultarEstadoFactura(idFactura, ref resultado, ref tipoResultado);
            if (tipoResultado != "danger")
            {
                dynObj = JsonConvert.SerializeObject(oFactura);
                dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var item in dyn)
                {
                    factura.id_factura = (int)item.id_factura;
                    factura.valorPagado = (double)item.saldo;
                    factura.total = (double)item.valor_total;
                    factura.estado.Descripcion = (string)item.descripcion_estado_factura;

                }
            }
            return factura;
        }


        public void ActualizarEstadoFactura(Factura factura, ref string resultado, ref string tipoResultado)
        {

            ventasDatos.ActualizarEstadoFactura(factura.id_factura,factura.estado.id,Convert.ToDecimal(factura.valorPagado),
                SessionHelper.GetUser().ToString(), ref resultado, ref tipoResultado);
        }


        /// <summary>
        /// CONSULTA EL HISTORICO DE UNA FACTURA ESPECIFICA
        /// </summary>
        /// <param name="idFactura"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<HistoricoFactura> ConsultarHistoricoFacturaXid(int idFactura, ref string resultado, ref string tipoResultado)
        {
            List<HistoricoFactura> historicosXid = new List<HistoricoFactura>();
            var oHistorico = ventasDatos.ConsultarHistoricoFacturaXid(idFactura, ref resultado, ref tipoResultado);


            string dynObj2 = JsonConvert.SerializeObject(oHistorico);
            dynamic dyn2 = JsonConvert.DeserializeObject(dynObj2);

            foreach (var item in dyn2)
            {
                historicosXid.Add(new HistoricoFactura
                {
                    fecha = item.fecha_historico,
                    descripcion = item.descripcion_historico,
                    empleado = new Usuario((string)item.apellidos, (string)item.nombres),
                    id_Factura = item.id_factura
                });
            }

            return historicosXid;
        }


        public void AnularFactura(int idFactura, string Motivo, ref string resultado, ref string tipoResultado)
        {

             ventasDatos.AnularFactura(idFactura, SessionHelper.GetUser().ToString(),
                Motivo, ref resultado, ref tipoResultado);
        }


    }
}