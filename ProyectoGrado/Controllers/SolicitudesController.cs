using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
using ProyectoGrado.Tags;
using Models.Comun;
using Helper;
using System.Text.RegularExpressions;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class SolicitudesController : Controller
    {


        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_consultar_solicitudes)]
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
        [Permiso(Permiso = RolesPermisos.puede_consultar_elementos)]
        public ActionResult ConsultarElementos()
        {
            string resultado = "", tipoResultado = "";
            List<Elemento> elementos;
            elementos = CatalogoSolicitudes.GetInstance().ConsultarElementos(ref resultado,ref tipoResultado);
            elementos.RemoveAt(0);
            return View("ConsultarElementos", elementos);
        }

        [HttpGet]
        public ActionResult ConsultarElementosModal()
        {
            string resultado = "", tipoResultado = "";
            List<Elemento> elementos;
            elementos = CatalogoSolicitudes.GetInstance().ConsultarElementos(ref resultado, ref tipoResultado);
            elementos.RemoveAt(0);
            return View("ConsultarElementosModal", elementos);
        }

        [HttpGet]
        public ActionResult AsignarElemento(int id)
        {
            Solicitud solicitud = CrearSolicitudVacia();
            solicitud.elemento.id_elemento = id;
            return View("GenerarSolicitud", solicitud);
        }

       

        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_ver_detalle_solicitud)]
        public ActionResult VerSolicitud(int id)
        {
            List<Solicitud> solicitudes = Session["solicitudes"] as List<Solicitud>;
            Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == id);
            ViewBag.idSolicitud = solicitud.id_solicitud;
            return View("VerSolicitud", solicitud);
        }

       
        [HttpGet]
        public ActionResult GenerarSolicitud()
        {
            return View(CrearSolicitudVacia());
        }

        [HttpPost]
        public ActionResult GenerarSolicitud(Solicitud solicitud)
        {
            string res = "",tipores = "";
            string resultado = "", tipoResultado = "";
            CatalogoSolicitudes.GetInstance().GenerarSolicitud(solicitud,ref resultado,ref tipoResultado);
            if (tipoResultado == "danger")
            {
                TempData["mensaje"] = "No se ha generado la solicitud correctamente. Verifique la información registrada";
                TempData["estado"] = tipoResultado;
                return View(solicitud);
            }
            else
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("ConsultarSolicitudes", CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref res, ref tipores));
            }

        }


        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_cambiar_estado_solicitud)]
        public ActionResult CambiarEstado(string id)
        {
            Solicitud solicitud;
            string resultado = "", tipoResultado = "";
            if (id != "idSeleccionado" && id != "CrearElemento" && id != "GenerarSolicitud")
            {
                int idSolicitud = Convert.ToInt32(id);
                solicitud = CatalogoSolicitudes.GetInstance().ConsultaEstadoSolicitud_X_id(idSolicitud, ref resultado, ref tipoResultado);
                solicitud.id_solicitud = idSolicitud;
                solicitud.estadoSolicitudSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarEstadosSolicitud(), "id", "Descripcion");
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                TempData["idEstadoActual"] = solicitud.estadoSolicitud.id;
                return View(solicitud);
            }
            else
            {
                
                List<Solicitud> solicitudes = new List<Solicitud>();
                solicitudes = CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref resultado, ref tipoResultado);
                TempData["mensaje"] = "Por favor seleccione una opción";
                TempData["estado"] = "danger";
                return View("ConsultarSolicitudes",solicitudes);

            }
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
        [Permiso(Permiso = RolesPermisos.puede_agregar_elemento)]
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

        [Permiso(Permiso = RolesPermisos.puede_crear_solicitudes)]
        public Solicitud CrearSolicitudVacia()
        {
            string res = "", tipores = "";
            Solicitud solicitud = new Solicitud();
            solicitud.prioridadSolicitudSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarTiposPrioridad(), "id", "Descripcion");
            solicitud.estadoSolicitudSelect = new SelectList(CatalogoSolicitudes.GetInstance().ConsultarEstadosSolicitud(), "id", "Descripcion");
            solicitud.ListaServiciosSelect = new SelectList(CatalogoServicios.GetInstance().ConsultarServicios(ref res, ref tipores), "id_servicio", "descripcion");
            solicitud.ListaClientesSelect = new SelectList(CatalogoUsuarios.GetInstance().ConsultarClientes("", ref res, ref tipores), "idUsuario", "NombresApellidosDocumento");
            return solicitud;
        }
        #region Escalar

        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_escalar_solicitud)]
        public ActionResult Escalar(string id)
        {
            string resultado = "", tipoResultado = "";
            if (id != "idSeleccionado" && id != "CrearElemento" && id != "GenerarSolicitud")
            {
                int idSolicitud = Convert.ToInt32(id);
                
                List<Solicitud> solicitudes = Session["solicitudes"] as List<Solicitud>;
                Solicitud solicitud = solicitudes.Find(x => x.id_solicitud == idSolicitud);
                ViewBag.idSolicitud = solicitud.id_solicitud;

                List<Usuario> usuarios;
                usuarios = CatalogoUsuarios.GetInstance().ConsultarEmpleados("", ref resultado, ref tipoResultado);
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuarios[i].estado != "Activo" || (SessionHelper.GetUser().ToString() == usuarios[i].identificacion))
                        usuarios.RemoveAt(i);
                }
                solicitud.ListaEmpleadosSelect = new SelectList(usuarios, "identificacion", "nombres");


                return View(solicitud);
            }else
            {
                List<Solicitud> solicitudes = new List<Solicitud>();
                solicitudes = CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref resultado, ref tipoResultado);
                TempData["mensaje"] = "Por favor seleccione una opción";
                TempData["estado"] = "danger";
                return View("ConsultarSolicitudes", solicitudes);
            }
        }


        [HttpPost]
        public ActionResult Escalar(Solicitud solicitud)
        {
            string res = "", tipores = "";
            string resultado = "", tipoResultado = "";
            CatalogoSolicitudes.GetInstance().EscalarSolicitud(solicitud,ref resultado,ref tipoResultado);

            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultarSolicitudes", CatalogoSolicitudes.GetInstance().ConsultarSolicitudes(ref res, ref tipores));
        }


        #endregion

        [HttpGet]
        public ActionResult ConsultarHistorico(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoSolicitud> historico= CatalogoSolicitudes.GetInstance().ConsultarHistoricoSolicitudX_id(id,ref resultado,ref tipoResultado);
            ViewBag.idSolicitud = historico[0].id_solicitud;
            return View(historico);
        }
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_agregar_anotacion_solicitud)]
        public ActionResult AgregarAnotacionModal(int id)
        {
            Solicitud solicitud= CrearSolicitudVacia();
            solicitud.id_solicitud=id;
            return View("AgregarAnotacionModal",solicitud);
        }
        [HttpPost]
        public ActionResult AgregarAnotacion(int id_Solicitud,string descripcion)
        {
            string resultado = "", tipoResultado = "";
            Solicitud solicitud =  null;
            List<Solicitud> solicitudes;
            var regexItem = new Regex(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,300}$");

            if (regexItem.IsMatch(descripcion))
            {
                TempData["mensaje"] = "Anotación agregada correctamente al historico";
                TempData["estado"] = "success";
                CatalogoSolicitudes.GetInstance().AgregarAnotacionHistorico(id_Solicitud, descripcion, ref resultado, ref tipoResultado);
                solicitudes = Session["solicitudes"] as List<Solicitud>;
                solicitud = solicitudes.Find(x => x.id_solicitud == id_Solicitud);
                return View("VerSolicitud", solicitud);
            }

            TempData["mensaje"] = "Los Caracteres Especiales no son permitidos";
            TempData["estado"] = "danger";
            solicitudes = Session["solicitudes"] as List<Solicitud>;
            solicitud = solicitudes.Find(x => x.id_solicitud == id_Solicitud);
            return View("VerSolicitud", solicitud);
        }

        
    }
}
