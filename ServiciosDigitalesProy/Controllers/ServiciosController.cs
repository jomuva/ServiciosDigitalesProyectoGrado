using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
namespace ServiciosDigitalesProy.Controllers
{
    public class ServiciosController : Controller
    {

        [HttpGet]
        public ActionResult AgregarServicio()
        {
            return View("AdicionarServicio");
        }

      
        [HttpPost]
        public ActionResult AgregarServicio(Servicio model)
        {

            string resultado = "", tipoResultado = "";
            if (ModelState.IsValid)
            {
                CatalogoServicios.GetInstance().AgregarServicio(model, out resultado, out tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return RedirectToAction("ConsultarServicios");
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View("AdicionarServicio");

        }


        [HttpGet]
        public ActionResult ConsultarServicios()
        {
            string resultado = "", tipoResultado = "";
            List<Servicio> servicios;
            servicios = CatalogoServicios.GetInstance().ConsultarServicios(ref resultado, ref tipoResultado);
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            return View("ConsultaServicios", servicios);
            
        }



        /// <summary>
        /// Muestra la vista del formulario para actualizar servicio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModificarServicio(int id)
        {
            string resultado = "", tipoResultado = "";
            List<Servicio> servicios;
            Servicio servicio;
            servicios = CatalogoServicios.GetInstance().ConsultarServicio(id,ref resultado, ref tipoResultado);

            servicio = servicios.First();
            return View("ModificarServicio", servicio);
        }

        /// <summary>
        /// Actualiza el servicio seleccionado
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateServicio(Servicio servicio)
        {
            string resultado = "", tipoResultado = "";
            string res="", tipoRes="";
            if (ModelState.IsValid)
            {
                CatalogoServicios.GetInstance().ModificarServicio(servicio, ref res, ref tipoRes);
                List<Servicio> servicios;
                servicios = CatalogoServicios.GetInstance().ConsultarServicios(ref resultado, ref tipoResultado);
                TempData["mensaje"] = res;
                TempData["estado"] = tipoRes;

                return View("RespuestaConsultaProductos", servicios);

            }

            return RedirectToAction("ModificarServicio", servicio.id_servicio);
        }


        [HttpGet]
        public ActionResult VolverDetallesServicio()
        {
            string resultado = "", tipoResultado = "";
            List<Servicio> servicios;
            servicios = CatalogoServicios.GetInstance().ConsultarServicios(ref resultado, ref tipoResultado);
            return View("ConsultaServicios", servicios);
        }



    }
}
