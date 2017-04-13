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
        public ActionResult CambiarEstado(string id)
        {
            Solicitud solicitud;
            int idSolicitud = Convert.ToInt32(id);
            string resultado = "", tipoResultado = "";

            solicitud = CatalogoSolicitudes.GetInstance().ConsultaEstadoSolicitud_X_id(idSolicitud,ref resultado, ref tipoResultado);
            solicitud.id_solicitud = idSolicitud;
            solicitud.estadoSolicitudSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarEstadosSolicitud(), "id", "Descripcion");
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            TempData["idEstadoActual"] = solicitud.estadoSolicitud.id;
            return View(solicitud);
        }

        
        [HttpPost]
        public ActionResult ModificarEstadoSolicitud(Solicitud solicitud)
        {
            string res = "", tipores = "";
            string resultado = "", tipoResultado = "";
            CatalogoSolicitudes.GetInstance().CambiarEstadoSolicitud
                                                                (solicitud.id_solicitud, 
                                                                (int)TempData.Peek("idEstadoActual"),
                                                                solicitud.estadoSolicitud.id,
                                                                ref resultado, ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultarSolicitudes", CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref res, ref tipores));
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
