using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
using ProyectoGrado.Tags;
using Models.Comun;
namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class SolicitudesController : Controller
    {


        [HttpGet]
        [PermisoAttribute(Permiso = RolesPermisos.Puede_consultar_solicitud)]
        public ActionResult ConsultarSolicitudes()
        {
            string resultado = "", tipoResultado = "";
            List<Solicitud> solicitudes =  new List<Solicitud>();
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
      
        [HttpGet]
        public ActionResult VerSolicitud(int id)
        {
            List<Solicitud> solicitudes = Session["solicitudes"] as List<Solicitud>;
            Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == id);
            ViewBag.idSolicitud = solicitud.id_solicitud;
            return View("VerSolicitud", solicitud);
        }

        [HttpGet]
        public ActionResult CambiarEstado(object id)
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
        public ActionResult CrearElemento()
        {
            Elemento element = new Elemento();
            element.tiposElementoSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarTiposElemento(), "id", "Descripcion");
            element.categoriasElementoSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarCategoriasElemento(), "id", "Descripcion");
            return View(element);
        }

        [HttpPost]
        public ActionResult CrearElemento(Elemento elemento)
        {
            string resultado = "", tipoResultado = "";
            CatalogoSolicitudes.GetInstance().AgregarElemento(elemento,ref resultado,ref tipoResultado);
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultarSolicitudes", Session["solicitudes"] as List<Solicitud>);
        }


    }
}
