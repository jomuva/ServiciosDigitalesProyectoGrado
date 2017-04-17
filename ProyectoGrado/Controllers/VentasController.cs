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
            Factura factura = CatalogoVentas.GetInstance().CrearFacturaSinRegistros(ref resultado, ref tipoResultado);
            Session["Factura"] = factura;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View(factura);
        }

        [HttpGet]
        public ActionResult BuscarClientes()
        {
            string resultado = "", tipoResultado = "";
            List<Usuario> clientes = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);

            return View(clientes);
        }


        [HttpGet]
        public ActionResult AsignarCliente(string id)
        {
            string resultado = "", tipoResultado = "";
            Factura factura = Session["Factura"] as Factura;
            List<Usuario> Clientes = CatalogoUsuarios.GetInstance().ConsultarClientes(id, ref resultado, ref tipoResultado);
            Usuario cliente = Clientes.Find(x => x.identificacion == id);
            factura.cliente = cliente;
            factura.cliente.NombresApellidos = cliente.nombres + " " + cliente.apellidos;
            TempData["mensaje"] = "Cliente Asignado Correctamente";
            TempData["estado"] = "success";
            Session["Factura"] = factura;
            return View("CrearFactura", factura);
        }


        [HttpGet]
        public ActionResult BuscarProducto()
        {
            string resultado = "", tipoResultado = "";
            List<Producto> productos = CatalogoProductos.GetInstance().ConsultarProductos("", ref resultado, ref tipoResultado);
            Session["Productos"] = productos;
            return View(productos);
        }

        [HttpGet]
        public ActionResult AdicionarProductoAFactura(int id)
        {
            string resultado = "", tipoResultado = "";
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

            TempData["mensaje"] = "Ingrese la cantidad del producto a vender";
            TempData["estado"] = "info";
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





        [HttpGet]
        public ActionResult ConsultarHistoricoInventarios(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioX_id(id, ref resultado, ref tipoResultado);
            ViewBag.idInventario = id;
            ViewBag.titulo = "";
            return View(historicos);
        }


        [HttpGet]
        public ActionResult ActualizarInventarioXProducto(int id)
        {
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref resultado, ref tipoResultado);
            Inventario inventario = inventarios.Find(x => x.id_inventario == id);
            TempData["Inventario"] = inventario;
            return View(inventario);
        }

        [HttpPost]
        public ActionResult ActualizarInventarioXProducto(Inventario inventario)
        {
            string resultado = "", tipoResultado = "";
            CatalogoInventarios.GetInstance().ActualizarInventarioXProducto(inventario, ref resultado, ref tipoResultado);
            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = "No se ha podido realizar la actualización del inventario.  Intente más tarde";
                TempData["estado"] = tipoResultado;
                return View(TempData.Peek("Inventario") as Inventario);
            }
            else
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                string res = "", tipores = "";
                return View("RespuestaConsultaInventarios", CatalogoInventarios.GetInstance().ConsultarInventarios("", ref res, ref tipores));
            }
        }



        [HttpGet]
        public ActionResult AgregarAnotacionInventario(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioX_id(id, ref resultado, ref tipoResultado);
            ViewBag.idInventario = id;
            Inventario inventario = new Inventario();
            inventario.id_inventario = id;
            return View("AgregarAnotacionModal", inventario);
        }

        [HttpPost]
        public ActionResult AgregarAnotacionInvent(Inventario inventario)
        {

            if (ModelState.IsValidField("historico.descripcion"))
            {
                string resultado = "", tipoResultado = "";
                CatalogoInventarios.GetInstance().AgregarAnotacionInventario(inventario, ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
            }
            else
            {
                TempData["mensaje"] = "Los caracteres especiales no son permitidos y el tamaño maximo de caracteres es 500";
                TempData["estado"] = "danger";
            }

            string res = "", tipoRes = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioX_id(inventario.id_inventario, ref res, ref tipoRes);
            ViewBag.idInventario = inventario.id_inventario;
            return View("ConsultarHistoricoInventarios", historicos);
        }
        #region Inventario Bajas



        [HttpGet]
        public ActionResult ConsultarInventariosBajas()
        {

            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarInventarioBajas(ref resultado, ref tipoResultado);
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View("ConsultarProductos");
            }
            else
            {
                ViewBag.titulo = "Bajas";
                return View("RespuestaConsultaInventarioBajas", inventarios);
            }
        }

        [HttpGet]
        public ActionResult ConsultarHistoricoInventariosBajas(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioBajasX_id(id, ref resultado, ref tipoResultado);

            ViewBag.idInventario = id;
            ViewBag.titulo = "Bajas";
            return View("ConsultarHistoricoInventarios", historicos);
        }


        [HttpGet]
        public ActionResult AdicionarBajas(int id)
        {
            Inventario inventario = new Inventario();
            inventario.producto.id_producto = id;

            return View("AdicionarBajas", inventario);
        }


        [HttpPost]
        public ActionResult AdicionarBajas(Inventario inventario)
        {
            if (ModelState.IsValidField("descripcion") && ModelState.IsValidField("cantidadExistencias"))
            {
                string resultado = "", tipoResultado = "";
                CatalogoInventarios.GetInstance().AgregarBaja(inventario, ref resultado, ref tipoResultado);
                if (tipoResultado == "danger")
                {
                    TempData["mensaje"] = resultado;
                    TempData["estado"] = tipoResultado;
                    return View(inventario);
                }
                else
                {
                    string res = "", tipores = "";
                    TempData["mensaje"] = resultado;
                    TempData["estado"] = tipoResultado;
                    return View("RespuestaConsultaInventarioBajas", CatalogoInventarios.GetInstance().ConsultarInventarioBajas(ref res, ref tipores));
                }
            }
            else
            {
                return View(inventario);
            }

        }

        [HttpGet]
        public ActionResult AgregarAnotacionInventarioBajas(int id)
        {
            string resultado = "", tipoResultado = "";
            ViewBag.idInventario = id;
            Inventario inventario = new Inventario();
            inventario.id_inventario = id;
            return View("AgregarAnotacionModalBajas", inventario);
        }


        [HttpPost]
        public ActionResult AgregarAnotacionInventBajas(Inventario inventario)
        {

            if (ModelState.IsValidField("historico.descripcion"))
            {
                string resultado = "", tipoResultado = "";
                CatalogoInventarios.GetInstance().AgregarAnotacionInventarioBajas(inventario, ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
            }
            else
            {
                TempData["mensaje"] = "Los caracteres especiales no son permitidos y el tamaño maximo de caracteres es 500";
                TempData["estado"] = "danger";
            }

            string res = "", tipoRes = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioBajasX_id(inventario.id_inventario, ref res, ref tipoRes);
            ViewBag.idInventario = inventario.id_inventario;
            ViewBag.titulo = "Bajas";
            return View("ConsultarHistoricoInventarios", historicos);
        }

        #endregion




    }
}
