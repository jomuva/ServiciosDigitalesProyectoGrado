using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ProyectoGrado.Catalogos;
using ProyectoGrado.Tags;
using System.ComponentModel.DataAnnotations;
using Models.Comun;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class InventariosController : Controller
    {


        /// <summary>
        /// Consulta las sucursales actuales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarSucursales()
        {
            string resultado = "", tipoResultado = "";

            List<Sucursal> sucursales = CatalogoInventarios.GetInstance().ConsultarSucursalesCompleto(ref resultado, ref tipoResultado);
            Session["sucursales"] = sucursales;
            if (tipoResultado != "danger")
            {
                return View("ConsultarSucursales", sucursales);
            }
            else
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return RedirectToAction("IndexInterno", "Home");
            }
        }


        /// <summary>
        /// Consulta el inventario de productos que hay en una sucursal específica y muestra
        /// en vista para su edicion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarInventarioXSucursal(int id)
        {
            //identificacion = identificacion == "0" ? "" : identificacion;
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal(id, ref resultado, ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("ConsultarSucursales", Session["sucursales"] as List<Sucursal>);
            }
            else
            {
                string res = "", tipoRes = "";
                List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
                int numProd = prod.Count;
                ViewBag.cantidadProductos = numProd;
                ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
                Session["nombreSucursalInventario"] = ViewBag.nombreSucursal;
                ViewBag.idSucursal = id;
                Session["idSucursal"] = id;
                return View(inventarios);
            }
        }

        [HttpGet]
        public ActionResult VolverVistaInventarioXSucursal()
        {
            string res = "", tipoRes = "";
            List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
            int numProd = prod.Count;
            ViewBag.cantidadProductos = numProd;

            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal((int)Session["idSucursal"], ref res, ref tipoRes);
            ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
            ViewBag.idSucursal = (int)Session["idSucursal"];
            return View("ConsultarInventarioXSucursal", inventarios);
        }

        /// <summary>
        /// Agrega un producto que no se haya vendido en una sucursal específica
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AgregarProductoASucursal()
        {
            //identificacion = identificacion == "0" ? "" : identificacion;
            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            productos = CatalogoProductos.GetInstance().ConsultarProductos("", ref resultado, ref tipoResultado);

            return View("AgregarProductoASucursal", productos);
        }

        [HttpGet]
        [Permiso(Permiso = RolesPermisos.Puede_Crear_Espacio_En_sucursal)]
        public ActionResult AsignarEspacioProductoASucursal(int id)
        {
            //identificacion = identificacion == "0" ? "" : identificacion;
            string resultado = "", tipoResultado = "";
            CatalogoInventarios.GetInstance().AsignarEspacioProductoASucursal(id, (int)Session["idSucursal"], ref resultado, ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;

            if (tipoResultado == "danger")
            {
                return RedirectToAction("AgregarProductoASucursal");
            }

            string res = "", tipoRes = "";
            List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
            int numProd = prod.Count;
            ViewBag.cantidadProductos = numProd;

            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal((int)Session["idSucursal"], ref resultado, ref tipoResultado);
            ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
            ViewBag.idSucursal = id;
            return View("ConsultarInventarioXSucursal", inventarios);
        }



        [HttpGet]
        [Permiso(Permiso = RolesPermisos.Puede_Trasladar_Producto)]
        public ActionResult TrasladarProductoASucursal(int id)
        {
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref resultado, ref tipoResultado);
            Inventario inventario = inventarios.Find(x => x.id_inventario == id);
            inventario.producto.sucursalesSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarSucursales(), "id_sucursal", "nombre");
            ViewBag.nombreSucursal = (string)Session["nombreSucursalInventario"];
            return View(inventario);

        }

        /// <summary>
        /// TRASLADA UN PRODUCTO DE UNA SUCURSAL A OTRA 
        /// </summary>
        /// <param name="inventario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TrasladarProductoASucursal(Inventario inventario)
        {
            string resultado = "", tipoResultado = "";
            int idSucursalActual = (int)Session["idSucursal"];

            if (inventario.producto.cantid == null)
            {
                TempData["mensaje"] = "El Campo Cantidad no puede estar vacio";
                TempData["estado"] = "danger";


                string res = "", tipoRes = "";
                List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref res, ref tipoRes);
                Inventario inventarioo = inventarios.Find(x => x.id_inventario == inventario.id_inventario);
                inventarioo.producto.sucursalesSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarSucursales(), "id_sucursal", "nombre");
                ViewBag.nombreSucursal = (string)Session["nombreSucursalInventario"];
                return View(inventarioo);
            }

            if (idSucursalActual == inventario.sucursal.id_sucursal)
            {
                TempData["mensaje"] = "No se pueden realizar traslados a la misma sucursal origen";
                TempData["estado"] = "danger";


                string res = "", tipoRes = "";
                List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref res, ref tipoRes);
                Inventario inventarioo = inventarios.Find(x => x.id_inventario == inventario.id_inventario);
                inventarioo.producto.sucursalesSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarSucursales(), "id_sucursal", "nombre");
                ViewBag.nombreSucursal = (string)Session["nombreSucursalInventario"];
                return View(inventarioo);
            }

            if (inventario.cantidadExistencias == 0)
            {
                TempData["mensaje"] = "No se pueden realizar traslados del producto.  Verifique la cantidad disponible en inventario";
                TempData["estado"] = "danger";

                string res = "", tipoRes = "";
                List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
                int numProd = prod.Count;
                ViewBag.cantidadProductos = numProd;

                List<Inventario> inventarios;
                inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal((int)Session["idSucursal"], ref resultado, ref tipoResultado);
                ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
                ViewBag.idSucursal = (int)Session["idSucursal"];
                return View("ConsultarInventarioXSucursal", inventarios);
            }

            if (Convert.ToInt32(inventario.producto.cantid) < 0)
            {
                TempData["mensaje"] = "el valor de la cantidad de unidades a trasladar no puede ser menor a cero";
                TempData["estado"] = "danger";
                string res = "", tipoRes = "";
                List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref res, ref tipoRes);
                Inventario inventarioo = inventarios.Find(x => x.id_inventario == inventario.id_inventario);
                inventarioo.producto.sucursalesSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarSucursales(), "id_sucursal", "nombre");
                ViewBag.nombreSucursal = (string)Session["nombreSucursalInventario"];
                return View(inventarioo);
            }
            if (inventario.cantidadExistencias >= Convert.ToInt32(inventario.producto.cantid))
            {

                CatalogoInventarios.GetInstance().TrasladarProductoASucursal(inventario, idSucursalActual, ref resultado, ref tipoResultado);

                if (resultado.Equals("An error occurred while executing the command definition. See the inner exception for details."))
                {
                    TempData["mensaje"] = "Antes de trasladar el producto, verifique que se ha asignado un espacio a la sucursal destino";
                    TempData["estado"] = "danger";

                }
                else
                {
                    TempData["mensaje"] = resultado;
                    TempData["estado"] = tipoResultado;
                }
                string res = "", tipoRes = "";
                List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
                int numProd = prod.Count;
                ViewBag.cantidadProductos = numProd;

                List<Inventario> inventarios;
                inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal((int)Session["idSucursal"], ref resultado, ref tipoResultado);
                ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
                ViewBag.idSucursal = (int)Session["idSucursal"];
                return View("ConsultarInventarioXSucursal", inventarios);
            }
            else
            {
                TempData["mensaje"] = "La cantidad de productos a trasladar debe ser menor o igual a la cantidad de existencias que tiene la sede";
                TempData["estado"] = "danger";
                string res = "", tipoRes = "";
                List<Inventario> inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref res, ref tipoRes);
                Inventario inventarioo = inventarios.Find(x => x.id_inventario == inventario.id_inventario);
                inventarioo.producto.sucursalesSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarSucursales(), "id_sucursal", "nombre");
                ViewBag.nombreSucursal = (string)Session["nombreSucursalInventario"];
                return View(inventarioo);
            }

        }



        [HttpGet]
        public ActionResult ConsultarInventarios()
        {
            //identificacion = identificacion == "0" ? "" : identificacion;
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios("", ref resultado, ref tipoResultado);
            //TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("ConsultarInventarios");
            }
            else
            {
                ViewBag.titulo = "";
                return View("RespuestaConsultaInventarios", inventarios);
            }
        }

        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_ver_historico_inventario)]

        public ActionResult ConsultarHistoricoInventarios(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioX_id(id, ref resultado, ref tipoResultado);
            ViewBag.idInventario = id;
            ViewBag.titulo = "";
            return View(historicos);
        }


        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_agregar_existancias_inventario)]
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

                string res = "", tipoRes = "";
                List<Producto> prod = CatalogoProductos.GetInstance().ConsultarProductos("", ref res, ref tipoRes);
                int numProd = prod.Count;
                ViewBag.cantidadProductos = numProd;

                List<Inventario> inventarios;
                inventarios = CatalogoInventarios.GetInstance().ConsultarProductosXSucursal((int)Session["idSucursal"], ref resultado, ref tipoResultado);
                ViewBag.nombreSucursal = inventarios.Count > 0 ? inventarios[0].sucursal.nombre : "";
                Session["nombreSucursalInventario"] = ViewBag.nombreSucursal;
                ViewBag.idSucursal = (int)Session["idSucursal"];
                return View("ConsultarInventarioXSucursal", inventarios);


            }
        }



        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_agregar_anotacion_inventario)]

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


        [HttpGet]
        public ActionResult ConsultarExistenciasTotalesProductos()
        {
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarExistenciasTotalesProductos(ref resultado, ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return RedirectToAction("IndexInterno", "Home");
            }
            else
            {
                ViewBag.titulo = "";
                return View(inventarios);
            }
        }


        [HttpGet]
        public ActionResult AgregarSucursal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarSucursal(Sucursal sucursal)
        {
            string resultado = "", tipoResultado = "";
            CatalogoInventarios.GetInstance().AgregarSucursal(sucursal, ref resultado, ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return RedirectToAction("IndexInterno", "Home");
        }

        #region Inventario Bajas



        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_consultar_inventario_bajas)]
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
        [Permiso(Permiso = RolesPermisos.puede_ver_historio_inventario_bajas)]
        public ActionResult ConsultarHistoricoInventariosBajas(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos = CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioBajasX_id(id, ref resultado, ref tipoResultado);

            ViewBag.idInventario = id;
            ViewBag.titulo = "Bajas";
            return View("ConsultarHistoricoInventarios", historicos);
        }


        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_agregar_bajas_inventario)]
        public ActionResult AdicionarBajas(int id)
        {
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarInventarioBajas(ref resultado, ref tipoResultado);
            Inventario inventario = inventarios.Find(x => x.id_inventario == id);


            return View("AdicionarBajas", inventario);
        }


        [HttpPost]
        [Permiso(Permiso = RolesPermisos.puede_agregar_bajas_inventario)]
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
        [Permiso(Permiso = RolesPermisos.puede_agregar_anotacion_inventario_bajas)]

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
