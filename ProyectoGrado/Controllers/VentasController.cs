using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ProyectoGrado.Catalogos;
using ServiciosDigitalesProy.Catalogos;
using ProyectoGrado.Tags;
using System.ComponentModel.DataAnnotations;
using Rotativa;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class VentasController : Controller
    {
        //public Factura factura;

        [HttpGet]
        public ActionResult CrearFactura()
        {
            string resultado = "", tipoResultado = "";
            int idFactura = CatalogoVentas.GetInstance().ObtenerIdUltimaFacturaGenerada(ref resultado, ref tipoResultado) + 1;
            DateTime horaActual = DateTime.Now;
            if (idFactura > 1)
            {
                Factura factura = new Factura(idFactura, horaActual);
                Session["Factura"] = factura;
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View(factura);
            }
            else
            {
                TempData["mensaje"] = "No se ha podido iniciar la creación de factura. Intente más tarde";
                TempData["estado"] = "danger";
                return RedirectToAction("IndexInterno", "Home");
            }
        }


        /// <summary>
        /// Consulta la lista de clientes y la agrega aL MODAL
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BuscarClientes()
        {
            Factura factura = Session["Factura"] as Factura;
            string resultado = "", tipoResultado = "";
            List<Usuario> clientes = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);
            List<Usuario> clientesActivos = new List<Usuario>();
            Usuario cliente;

            if (clientes != null)
            {
                foreach (var item in clientes)
                {
                    cliente = (item.estado == "Activo") ? item : null;
                    if (cliente != null)
                    {
                        clientesActivos.Add(cliente);
                    }
                    cliente = null;
                }

                return View(clientesActivos);
            }
            else
            {
                TempData["mensaje"] = "No hay clientes registrados en base de datos.";
                TempData["estado"] = "danger";
                return View("CrearFactura", factura);
            }
        }


        [HttpGet]
        public ActionResult AsignarCliente(string id)
        {
            string resultado = "", tipoResultado = "";
            Factura factura = Session["Factura"] as Factura;
            List<Usuario> Clientes = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);
            Usuario cliente = Clientes.Find(x => x.identificacion == id);

            if (factura.cliente.identificacion == "")
            {
                factura.cliente = cliente;
                factura.cliente.NombresApellidos = cliente.nombres + " " + cliente.apellidos;
                TempData["mensaje"] = "Cliente Asignado Correctamente";
                TempData["estado"] = "success";
                Session["Factura"] = factura;
            }
            else
            {
                TempData["mensaje"] = "Ya existe un cliente asociado a esta Factura";
                TempData["estado"] = "danger";
            }
            return View("CrearFactura", factura);


        }


        /// <summary>
        ///  ABRE EL MODAL PARA ADICIONAR PRODUCTO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BuscarProducto()
        {
            string resultado = "", tipoResultado = "";
            Factura factura = Session["Factura"] as Factura;
            List<Producto> productos = CatalogoProductos.GetInstance().ConsultarProductos("", ref resultado, ref tipoResultado);
            List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref resultado, ref tipoResultado);

            List<Producto> productosDisponibles = new List<Producto>();
            Producto producto = null;
            Inventario temp = null;

            if (productos != null)
            {
                foreach (var item in productos)
                {
                    producto = (item.estado.id == 1) ? item : null;
                    if (producto != null)
                    {

                        temp = inventarios.Find(x => x.producto.id_producto == producto.id_producto);
                        producto.cantid = (temp.cantidadExistencias).ToString();
                        productosDisponibles.Add(producto);
                    }
                    producto = null;
                }

                Session["Productos"] = productosDisponibles;
                return View(productosDisponibles);
            }
            else
            {
                TempData["mensaje"] = "No hay Productos registrados en base de datos, Comuniquese con el administrador y verifique inventario";
                TempData["estado"] = "danger";
                return View("CrearFactura", factura);
            }
        }


        /// <summary>
        /// AGREGA UN PRODUCTO SELECCIONADO EN EL MODAL A LA VISTA PRINCIPAL DE CREACION DE FACTURA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdicionarProductoAFactura(int id)
        {
            Factura factura = Session["Factura"] as Factura;
            List<Producto> productos = Session["Productos"] as List<Producto>;
            Producto producto = productos.Find(x => x.id_producto == id);

            DetalleFacturaProducto detalle;
            detalle = factura.listaDetallesProducto.Find(x => x.producto.id_producto == id);
            if (detalle == null)
            {
                factura.listaDetallesProducto.Add(new DetalleFacturaProducto
                {
                    producto = producto
                });
            }
            else
            {
                TempData["mensaje"] = "Ya se encuentra un item del mismo producto en la factura";
                TempData["estado"] = "info";
                return View("CrearFactura", factura);
            }

            TempData["mensaje"] = "Recuerda ingresar la cantidad del producto a vender";
            TempData["estado"] = "info";
            Session["Factura"] = factura;
            return View("CrearFactura", factura);
        }

        /// <summary>
        /// CONSULTA LAS SOLICITUDES ASOCIADAS AL CLIENTE DE LA FACTURA Y LAS ENVIA A LA VISTA MODAL
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult BuscarSolicitudes()
        {
            Factura factura = Session["Factura"] as Factura;
            string resultado = "", tipoResultado = "";
            List<Solicitud> solicitudes = CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref resultado, ref tipoResultado);
            List<Solicitud> solicitudesClientefactura = new List<Solicitud>();
            Solicitud solicitud;
            if (solicitudes != null)
            {
                foreach (var item in solicitudes)
                {
                    solicitud = (item.cliente.identificacion == factura.cliente.identificacion) ? item : null;
                    if (solicitud != null)
                    {
                        solicitudesClientefactura.Add(solicitud);
                    }
                    solicitud = null;
                }
                ViewBag.NombreCliente = factura.cliente.NombresApellidos;
                Session["Solicitudes"] = solicitudesClientefactura;
                return View(solicitudesClientefactura);

            }
            else
            {
                TempData["mensaje"] = "No hay solicitudes registradas en base de datos";
                TempData["estado"] = "danger";
                return View("CrearFactura", factura);
            }
        }

        /// <summary>
        /// AGREGA UNA SOLICITUD SELECCIONADA DESDE EL MODAL A LA FACTURA 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdicionarSolicitudAFactura(int id)
        {
            Factura factura = Session["Factura"] as Factura;
            List<Solicitud> solicitudes = Session["Solicitudes"] as List<Solicitud>;
            Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == id);

            DetalleFacturaSolicitud detalle;
            detalle = factura.listaDetallesSolicitud.Find(x => x.solicitud.id_solicitud == id);
            if (detalle == null)
            {
                factura.listaDetallesSolicitud.Add(new DetalleFacturaSolicitud
                {
                    solicitud = solicitud
                });
            }
            else
            {
                TempData["mensaje"] = "Ya se encuentra la misma solicitud en la factura";
                TempData["estado"] = "info";
                return View("CrearFactura", factura);
            }

            TempData["mensaje"] = "Solicitud agregada Correctamente";
            TempData["estado"] = "success";
            Session["Factura"] = factura;
            return View("CrearFactura", factura);
        }


        /// <summary>
        /// GENERA LA FACTURA Y LA ALISTA PARA MOSTRARLA AL USUARIO ANTES DE GUARDARLA EN BASE DE DATOS
        /// TAMBIEN SE VALIDA EN STOCK Y SE REALIZAN CÁLCULOS PARA EL VALOR TOTAL DE LA FACTURA
        /// </summary>
        /// <param name="facturaa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GenerarFactura(Factura facturaa)
        {
            Factura factura = Session["Factura"] as Factura;
            string res = "", tipores = "";
            int cantidad = 0;
            double Total = 0;
            if (factura.listaDetallesProducto.Count != 0)
            {
                for (int i = 0; i < facturaa.listaDetallesProducto.Count; i++)
                {
                    factura.listaDetallesProducto[i].cantidad = facturaa.listaDetallesProducto[i].cantidad;
                    if (facturaa.listaDetallesProducto[i].cantidad > 0)
                    {
                        cantidad = CatalogoInventarios.GetInstance().ConsultarCantidadProductoXid(facturaa.listaDetallesProducto[i].producto.id_producto, ref res, ref tipores);
                        if (facturaa.listaDetallesProducto[i].cantidad > cantidad)
                        {
                            TempData["mensaje"] = "No hay la cantidad de existencias suficientes para el producto " + facturaa.listaDetallesProducto[i].producto.nombre;
                            TempData["estado"] = "danger";
                            return View("CrearFactura", factura);
                        }
                        else
                        {
                            factura.listaDetallesProducto[i].subtotal = facturaa.listaDetallesProducto[i].cantidad * facturaa.listaDetallesProducto[i].producto.precio_venta;

                        }

                    }
                    else
                    {
                        TempData["mensaje"] = "En el campo Cantidad no se permiten valores menores o iguales a cero";
                        TempData["estado"] = "danger";
                        return View("CrearFactura", factura);
                    }
                    cantidad = 0;
                }

                // suma los precios de los items de los productos al total de la factura
                for (int i = 0; i < factura.listaDetallesProducto.Count; i++)
                {
                    Total = factura.listaDetallesProducto[i].subtotal + Total;

                }
            }

            //Suma los precios de las solicitudes agregadas, al total de la factura
            if (factura.listaDetallesSolicitud.Count != 0)
            {
                for (int i = 0; i < factura.listaDetallesSolicitud.Count; i++)
                {
                    Total = factura.listaDetallesSolicitud[i].solicitud.servicio.precio + Total;
                }
            }

            factura.total = Total;

            Session["Factura"] = factura;
            TempData["mensaje"] = "Factura Generada correctamente.  Haga clic en Guardar para confirmar";
            TempData["estado"] = "success";
            return View("GenerarFactura", factura);
        }


        /// <summary>
        /// Guarda la factura generada en BD junto con el total pagado
        /// </summary>
        /// <param name="facturaa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GuardarFactura(Factura facturaa)
        {
            Factura factura = Session["Factura"] as Factura;
            string resultado = "", tipoResultado = "";
            if (facturaa.valorPagado >= 0 && facturaa.valorPagado <= factura.total)
            {
                factura.estado.id = facturaa.valorPagado == 0 ? factura.estado.id = 4 : facturaa.valorPagado == factura.total ? 1 : facturaa.valorPagado < factura.total ? 3 : 2;
                factura.valorPagado = facturaa.valorPagado;
                Session["Factura"] = factura;
                CatalogoVentas.GetInstance().GuardarFactura(factura, ref resultado, ref tipoResultado);
                if (tipoResultado == "success")
                {
                    TempData["mensaje"] = "Factura Registrada Correctamente";
                    TempData["estado"] = "success";

                }
                else
                {
                    TempData["mensaje"] = "Creación de factura Fallida por error desde Base de datos.  Consulte con Soporte técnico";
                    TempData["estado"] = "danger";

                }
                return RedirectToAction("IndexInterno", "Home");
            }
            else
            {
                TempData["mensaje"] = "El valor pagado no puede exceder el total a pagar";
                TempData["estado"] = "danger";
                return View("GenerarFactura", factura);
            }



        }


        /// <summary>
        /// Vuelve a la vista crearFactura para modificar algun cambio antes de guardarla en BD
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModificarFacturaGenerada()
        {
            Factura factura = Session["Factura"] as Factura;
            return View("CrearFactura", factura);
        }

        /// <summary>
        /// ELIMINA UN ITEM PRODUCTO DENTRO DE LA FACTURA QUE SE ESTA GENERANDO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult eliminarItemProducto(int id)
        {
            Factura factura = Session["Factura"] as Factura;
            List<Producto> productos = Session["Productos"] as List<Producto>;

            DetalleFacturaProducto detalle;
            detalle = factura.listaDetallesProducto.Find(x => x.producto.id_producto == id);
            factura.listaDetallesProducto.Remove(detalle);

            TempData["mensaje"] = "Item removido Correctamente";
            TempData["estado"] = "info";
            Session["Factura"] = factura;

            return View("CrearFactura", factura);
        }

        /// <summary>
        /// ELIMINA UN ITEM SOLICITUD DENTRO DE LA FACTURA QUE SE ESTA GENERANDO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult eliminarItemSolicitud(int id)
        {
            Factura factura = Session["Factura"] as Factura;
            List<Solicitud> solicitudes = Session["Solicitudes"] as List<Solicitud>;
            Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == id);

            DetalleFacturaSolicitud detalle;
            detalle = factura.listaDetallesSolicitud.Find(x => x.solicitud.id_solicitud == id);

            factura.listaDetallesSolicitud.Remove(detalle);

            TempData["mensaje"] = "Item removido Correctamente";
            TempData["estado"] = "info";
            Session["Factura"] = factura;

            return View("CrearFactura", factura);
        }


        /// <summary>
        /// CONSULTA EL TOTAL DE LAS FACTURAS EXISTENTES Y LAS MUESTRA EN LA VISTA
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarFacturas()
        {
            string resultado = "", tipoResultado = "";
            List<Factura> facturas = new List<Factura>();

            facturas = CatalogoVentas.GetInstance().ConsultarFacturas(ref resultado, ref tipoResultado);

            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return RedirectToAction("IndexInterno", "Home");
            }
            Session["Facturas"] = facturas;
            return View(facturas);
        }


        [HttpGet]
        public ActionResult VerDetalleFactura(int id)
        {
            List<Factura> facturas = Session["Facturas"] as List<Factura>;
            Factura factura = facturas.Find(x => x.id_factura == id);
            factura.cliente.NombresApellidos = factura.cliente.nombres + " " + factura.cliente.apellidos;
            ViewBag.idFactura = factura.id_factura;
            return View(factura);
        }

        [HttpGet]
        public ActionResult ActualizarEstadoFactura(int id)
        {
            string resultado = "", tipoResultado = "";
            Factura factura = CatalogoVentas.GetInstance().ConsultarEstadoFactura(id, ref resultado, ref tipoResultado);
            Session["EstadoFactura"] = factura;
            Session["saldo"] = factura.valorPagado;
            ViewBag.idFactura = factura.id_factura;
            return View(factura);
        }



        [HttpPost]
        public ActionResult UpdateEstadoFactura(Factura factura)
        {
            string resultado = "", tipoResultado = "";
            List<Factura> facturas = CatalogoVentas.GetInstance().ConsultarFacturas(ref resultado, ref tipoResultado);

            if (factura.valorPagado > (double)Session["saldo"])
            {
                TempData["mensaje"] = "El valor pagado no puede exceder el total de la factura";
                TempData["estado"] = "danger";
                return View("ActualizarEstadoFactura", Session["EstadoFactura"] as Factura);
            }
            
            factura.estado.id = factura.valorPagado < (double)Session["saldo"] ? 3: factura.valorPagado == (double)Session["saldo"] ? 1 : factura.valorPagado == 0 ? 4 : 2;
            CatalogoVentas.GetInstance().ActualizarEstadoFactura(factura, ref resultado, ref tipoResultado);


            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultarFacturas", facturas);
        }



        [HttpGet]
        public ActionResult ConsultarHistoricoFacturaXid(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoFactura> historico = CatalogoVentas.GetInstance().ConsultarHistoricoFacturaXid(id, ref resultado, ref tipoResultado);
            ViewBag.idFactura = historico[0].id_Factura;
            return View(historico);
        }



        [HttpGet]
        public ActionResult AnularFactura(int id)
        {

            Factura factura = new Factura();
            factura.id_factura = id;

            return View(factura);
        }

        [HttpPost]
        public ActionResult AnularFactura(Factura fact)
        {
            string resultado = "", tipoResultado = "";
            List<Factura> facturas = CatalogoVentas.GetInstance().ConsultarFacturas(ref resultado, ref tipoResultado);

            CatalogoVentas.GetInstance().AnularFactura(fact.id_factura,fact.estado.Descripcion, ref resultado, ref tipoResultado);
            
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultarFacturas", facturas);
        }




        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("pruebaPDF")
            {
                FileName = Server.MapPath("~/Reportes/FacturaGenerada.pdf")
            };

        }

        public ActionResult pruebaPDF()
        {
            return View();
        }



    }
}
