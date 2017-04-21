
using ServiciosDigitalesProy.Catalogos;
using ServiciosDigitalesProy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoGrado.Tags;
using Helper;

namespace ProyectoGrado.Controllers
{
    public class HomeController : Controller
    {
        [Autenticado]
        public ActionResult Index()
        {
            TempData["mensaje"] = "Bienvenido " + SessionHelper.GetNombreUsuarioLogueado() +  "!!!";
            TempData["estado"] = "success";
            CatalogoUsuarios.GetInstance().CambiarEstadoLogueo(SessionHelper.GetNombreUsuarioLogueado());
            return View();
        }

        public ActionResult IndexInterno()
        {
          
            return View("Index");
        }

        public ActionResult IndexLogo()
        {
           
            return View("Index");
        }

        public ActionResult Login()
        {
            if (Request.IsAjaxRequest())
                return View();

            else
                return PartialView("Login");

            //return View();
        }



        
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            string res = "", tipores = "";
            if (!user.username.Equals("") && (!user.password.Equals("")))
            {
               
                string resultado = "", tipoResultado = "";
                CatalogoUsuarios.GetInstance().ValidarAutenticacionLogin(user, ref resultado, ref tipoResultado);
                if (tipoResultado=="danger" || tipoResultado == "")
                {
                    TempData["mensaje"] = resultado;
                    TempData["estado"] = "danger";
                    return PartialView("Login");
                }else
                {
                    CatalogoUsuarios.GetInstance().ConsultarEstadoLogueoUser(user.username,ref res,ref tipores);
                    if (tipores == "info")
                    {
                        TempData["mensaje"] = res;
                        TempData["estado"] = tipores;
                        return PartialView("Login");
                    }

                    return RedirectToAction("Index");
                }
               
            }else
            {
                TempData["mensaje"] = "Por favor Ingrese los dos campos obligatorios";
                TempData["estado"] = "danger";
                return PartialView("Login", user);
            }

        }

        [Autenticado]
        public ActionResult Salir()
        {
            CatalogoUsuarios.GetInstance().CambiarEstadoLogueo(SessionHelper.GetNombreUsuarioLogueado());
            SessionHelper.DestroyUserSession();
            Session.Abandon();
            return Redirect("~/");
        }

       
    }
}