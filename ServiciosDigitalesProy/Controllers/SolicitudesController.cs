using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
namespace ServiciosDigitalesProy.Controllers
{
    public class SolicitudesController : Controller
    {

      
        [HttpGet]
        public ActionResult ConsultarSolicitudes()
        {
            string resultado = "", tipoResultado = "";
            List<Solicitud> solicitudes;
            solicitudes = CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref resultado, ref tipoResultado);
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            Session["solicitudes"] = solicitudes;
            return View(solicitudes);
        }

        [HttpGet]
        public ActionResult ConsultarElemento(int id)
        {
            List<Solicitud> solicitudes = Session["solicitudes"] as List<Solicitud>;
            Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == id);
            ViewBag.NombreCliente = solicitud.cliente.nombres;
            if (solicitud.elemento.modelo == "No tiene elemento asignado")
            {
                TempData["mensaje"] = "No hay ningun elemento asociado a esta solicitud";
                TempData["estado"] = "info";
                return View("ConsultarSolicitudes",solicitudes);
            }
            Elemento elemento = solicitud.elemento;
            return View("ConsultaElemento",elemento);
        }

        [HttpPost]
        public ActionResult ConsultarProductos(string identificacion)
        {

            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            productos = CatalogoProductos.GetInstance().ConsultarProductos(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View("ConsultarProductos");
            }
            else
            {
                return View("RespuestaConsultaProductos", productos);
            }
        }

        


    }
}
