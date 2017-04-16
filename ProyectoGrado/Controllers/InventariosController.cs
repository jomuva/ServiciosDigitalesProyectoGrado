using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ProyectoGrado.Catalogos;
using ProyectoGrado.Tags;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class InventariosController : Controller
    {



        [HttpGet]
        public ActionResult ConsultarInventarios()
        {

            return View("ConsultarInventarios");
        }


        [HttpPost]
        public ActionResult ConsultarInventarios(string identificacion)
        {
            identificacion = identificacion == "0" ? "" : identificacion;
            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
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
