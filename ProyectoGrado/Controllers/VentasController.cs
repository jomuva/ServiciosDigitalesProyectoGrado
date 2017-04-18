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
            int idFactura = CatalogoVentas.GetInstance().ObtenerIdUltimaFacturaGenerada(ref resultado, ref tipoResultado)+1;
            DateTime horaActual = DateTime.Now;
            if (idFactura > 1)
            {
                Factura factura = new Factura(idFactura,horaActual);
                Session["Factura"] = factura;
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View(factura);
            }
            else
            {
                return View();
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
            else {
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
            List<Producto> productosDisponibles = new List<Producto>();
            Producto producto = null;


            if (productos != null)
            {
                foreach (var item in productos)
                {
                    producto = (item.estado.id == 1) ? item : null;
                    if (producto != null)
                    {
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
            List<Solicitud> solicitudesClientefactura =  new List<Solicitud>();
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
                if (solicitudesClientefactura.Count !=0)
                {
                    ViewBag.NombreCliente = factura.cliente.NombresApellidos;
                    Session["Solicitudes"] = solicitudesClientefactura;
                    return View(solicitudesClientefactura);
                }else
                {
                    TempData["mensaje"] = "No hay solicitudes asociadas al cliente en base de datos";
                    TempData["estado"] = "info";
                    return View("CrearFactura", factura);
                }
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



        [HttpPost]
        public ActionResult ConfirmarItems(Factura facturaa)
        {
            Factura factura = Session["Factura"] as Factura;

            for (int i=0;i<facturaa.listaDetallesProducto.Count;i++)
            {
                factura.listaDetallesProducto[i].cantidad = facturaa.listaDetallesProducto[i].cantidad;
            }

            Session["Factura"] = factura;
            TempData["mensaje"] = "Producto Agregado";
            TempData["estado"] = "info";
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





    }
}
